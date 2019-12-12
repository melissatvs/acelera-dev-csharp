using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Codenation.Challenge.DTOs;
using Microsoft.AspNetCore.Mvc;
using Codenation.Challenge.Controllers;

namespace Codenation.Challenge
{
    public class CompanyControllerTest
    {       
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Find_By_Id(int id)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCompanyService().Object;
            var expected = fakes.Mapper.Map<CompanyDTO>(fakeService.FindById(id));

            var controller = new CompanyController(fakeService, fakes.Mapper);
            var result = controller.Get(id);
            
            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as CompanyDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new CompanyDTOIdComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Should_Be_OK_When_Find_By_Accelaration_Id(int accelerationId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCompanyService().Object;
            var expected = fakeService.FindByAccelerationId(accelerationId).
                Select(x => fakes.Mapper.Map<CompanyDTO>(x)).
                ToList();

            var controller = new CompanyController(fakeService, fakes.Mapper);
            var result = controller.GetAll(accelerationId: accelerationId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<CompanyDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new CompanyDTOIdComparer());  
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Find_By_User_Id(int userId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCompanyService().Object;
            var expected = fakeService.FindByUserId(userId).
                Select(x => fakes.Mapper.Map<CompanyDTO>(x)).
                ToList();

            var controller = new CompanyController(fakeService, fakes.Mapper);
            var result = controller.GetAll(userId: userId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<CompanyDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new CompanyDTOIdComparer());  
        }

        [Fact]
        public void Should_Be_Ok_When_Post()
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCompanyService().Object;
            var expected = fakes.Get<CompanyDTO>().First();
            expected.Id = 0;

            var controller = new CompanyController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as CompanyDTO;
            Assert.NotNull(actual);
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Slug, actual.Slug);
        }
     
    }
}
