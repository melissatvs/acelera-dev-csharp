using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Source;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Codenation.Challenge.Controllers;

namespace Codenation.Challenge
{
    public class AuthenticationTest
    {
        private TestServer server;
        private TestServer authServer;

        public AuthenticationTest()
        {
            var authBuilder = new WebHostBuilder().
                UseEnvironment("Development").
                UseStartup<StartupIdentityServer>();
            authServer = new TestServer(authBuilder);            
            authServer.BaseAddress = new Uri("http://localhost:5000");

            var builder = new WebHostBuilder().
                UseEnvironment("Testing").
                ConfigureServices(services => {
                    services.Configure<JwtBearerOptions>( "Bearer", jwtOpts => {
                        jwtOpts.BackchannelHttpHandler = authServer.CreateHandler();
                    });
                }).
                UseStartup<Startup>();

            server = new TestServer(builder);            
            server.BaseAddress = new Uri("http://localhost:5000");
        }       

        private Dictionary<string, string> GetTokenParameters(string email, string password)
        {
            var parameters = new Dictionary<string, string>();
            parameters["client_id"] = "codenation.api_client";
            parameters["client_secret"] = "codenation.api_secret";
            parameters["grant_type"] = "password";
            parameters["scope"] = "codenation";
            parameters["username"] = email;
            parameters["password"] = password;
            return parameters;
        }

        private Token GetToken(string email, string password)
        {
            var parameters = GetTokenParameters(email, password);
            var client = authServer.CreateClient();
            var response = client.PostAsync("/connect/token", 
                new FormUrlEncodedContent(parameters)).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<Token>().Result;
        }

        [Fact]
        public void Should_Has_Authorize_Attribute_On_User_Controller()
        {
            var attributes = typeof(UserController).
                GetCustomAttributes(false).
                Select(x => x.GetType().Name).
                ToList();
            Assert.Contains("AuthorizeAttribute", attributes);
        }

        [Fact]
        public void Should_Challenge_Route_Be_Authorized_When_Call_With_No_Token()
        {
            var client = server.CreateClient();
            var actual = client.GetAsync("/api/challenge").Result;            
            Assert.NotEqual(HttpStatusCode.Unauthorized, actual.StatusCode);
        }

        [Fact]
        public void Should_Admin_Be_Authorized_On_Route_User()
        {
            var token = GetToken("tegglestone9@blog.com", "2epRrOi");
            Assert.NotNull(token);

            var client = server.CreateClient();
            client.SetBearerToken(token.access_token);            

            var actual = client.GetAsync("/api/user/1").Result;
            Assert.NotEqual(HttpStatusCode.Unauthorized, actual.StatusCode);
            Assert.NotEqual(HttpStatusCode.Forbidden, actual.StatusCode);
        }

    }
}

