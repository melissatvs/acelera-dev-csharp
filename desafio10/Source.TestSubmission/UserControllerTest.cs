using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge
{
    public class UserControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Get_By_Id(int id)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeUserService().Object;
            var expected = fakes.Mapper.Map<UserDTO>(fakeService.FindById(id));

            var controller = new UserController(fakeService, fakes.Mapper);
            var result = controller.Get(id);
            
            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as UserDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new UserDTOIdComparer());
        }

        [Theory]
        [InlineData("Velvet Grass")]
        [InlineData("Progesterone")]
        public void Should_Be_Ok_When_Get_All_By_Accelaration_Name(string accelerationName)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeUserService().Object;
            var expected = fakeService.FindByAccelerationName(accelerationName).
                Select(x => fakes.Mapper.Map<UserDTO>(x)).
                ToList();

            var controller = new UserController(fakeService, fakes.Mapper);
            var result = controller.GetAll(accelerationName: accelerationName);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<UserDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new UserDTOIdComparer());                  
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Get_All_By_Company_Id(int companyId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeUserService().Object;
            var expected = fakeService.FindByCompanyId(companyId).
                Select(x => fakes.Mapper.Map<UserDTO>(x)).
                ToList();

            var controller = new UserController(fakeService, fakes.Mapper);
            var result = controller.GetAll(companyId: companyId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<UserDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new UserDTOIdComparer());               
        }

        [Fact]
        public void Should_Be_OK_When_Post()
        {          
            var fakes = new Fakes();   
            var fakeService = fakes.FakeUserService().Object;
            var expected = fakes.Get<UserDTO>().First();
            expected.Id = 0;

            var controller = new UserController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as UserDTO;
            Assert.NotNull(actual);
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.FullName, actual.FullName);
            Assert.Equal(expected.Nickname, actual.Nickname);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.Password, actual.Password);
        }

    }
}
