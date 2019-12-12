using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Codenation.Challenge.DTOs;
using Microsoft.AspNetCore.Mvc;
using Codenation.Challenge.Controllers;

namespace Codenation.Challenge
{
    public class CandidateControllerTest
    {
        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,2)]
        [InlineData(3,3,3)]
        public void Should_Be_Ok_When_Find_By_Id(int userId, int accelerationId, int companyId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCandidateService().Object;
            var expected = fakes.Mapper.Map<CandidateDTO>(fakeService.FindById(userId, accelerationId, companyId));

            var controller = new CandidateController(fakeService, fakes.Mapper);
            var result = controller.Get(userId, accelerationId, companyId);
            
            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as CandidateDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new CandidateDTOIdComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Find_By_Company_Id(int companyId)
        {
           var fakes = new Fakes();   
            var fakeService = fakes.FakeCandidateService().Object;
            var expected = fakeService.FindByCompanyId(companyId).
                Select(x => fakes.Mapper.Map<CandidateDTO>(x)).
                ToList();

            var controller = new CandidateController(fakeService, fakes.Mapper);
            var result = controller.GetAll(companyId: companyId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<CandidateDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new CandidateDTOIdComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Find_By_Accelaration_Id(int accelerationId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCandidateService().Object;
            var expected = fakeService.FindByAccelerationId(accelerationId).
                Select(x => fakes.Mapper.Map<CandidateDTO>(x)).
                ToList();

            var controller = new CandidateController(fakeService, fakes.Mapper);
            var result = controller.GetAll(accelerationId: accelerationId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<CandidateDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new CandidateDTOIdComparer());
        }

        [Fact]
        public void Should_Be_Ok_When_Post()
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeCandidateService().Object;
            var expected = new CandidateDTO() {
                UserId = 5, 
                AccelerationId = 1,
                CompanyId = 1,
                Status = 99
            };

            var controller = new CandidateController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as CandidateDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected.UserId, actual.UserId);
            Assert.Equal(expected.AccelerationId, actual.AccelerationId);
            Assert.Equal(expected.CompanyId, actual.CompanyId);
            Assert.Equal(expected.Status, actual.Status);
        }

    }
}
