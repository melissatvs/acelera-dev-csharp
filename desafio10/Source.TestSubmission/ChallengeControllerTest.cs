using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge
{
    public class ChallengeControllerTest
    {       
        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(3,3)]
        public void Should_Be_Ok_When_Find_By_Accelartion_And_User(int accelerationId, int userId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeChallengeService().Object;
            var expected = fakeService.FindByAccelerationIdAndUserId(accelerationId, userId).
                Select(x => fakes.Mapper.Map<ChallengeDTO>(x)).
                ToList();

            var controller = new ChallengeController(fakeService, fakes.Mapper);
            var result = controller.GetAll(accelerationId: accelerationId, userId: userId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<ChallengeDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new ChallengeDTOIdComparer()); 
        }

        [Fact]
        public void Should_Be_Ok_When_Post()
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeChallengeService().Object;
            var expected = fakes.Get<ChallengeDTO>().First();
            expected.Id = 0;

            var controller = new ChallengeController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as ChallengeDTO;
            Assert.NotNull(actual);
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Slug, actual.Slug);
        }

    }
}
