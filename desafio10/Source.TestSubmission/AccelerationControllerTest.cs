using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge
{
    public class AccelerationControllerTest
    {       
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Find_By_Id(int id)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeAccelerationService().Object;
            var expected = fakes.Mapper.Map<AccelerationDTO>(fakeService.FindById(id));

            var controller = new AccelerationController(fakeService, fakes.Mapper);
            var result = controller.Get(id);
            
            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as AccelerationDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new AccelerationDTOIdComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Should_Be_Ok_When_Find_By_Company_Id(int companyId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeAccelerationService().Object;
            var expected = fakeService.FindByCompanyId(companyId).
                Select(x => fakes.Mapper.Map<AccelerationDTO>(x)).
                ToList();

            var controller = new AccelerationController(fakeService, fakes.Mapper);
            var result = controller.GetAll(companyId: companyId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<AccelerationDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new AccelerationDTOIdComparer());
        }

        [Fact]
        public void Should_Be_Ok_When_Post()
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeAccelerationService().Object;
            var expected = fakes.Get<AccelerationDTO>().First();
            expected.Id = 0;

            var controller = new AccelerationController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as AccelerationDTO;
            Assert.NotNull(actual);
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Slug, actual.Slug);
            Assert.Equal(expected.ChallengeId, actual.ChallengeId);
        }
    
    }
}
