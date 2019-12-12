using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Codenation.Challenge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class SubmissionControllerTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Higher_Score_When_Get_By_Challenge_Id(int challengeId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeSubmissionService().Object;
            var expected = fakeService.FindHigherScoreByChallengeId(challengeId);

            var controller = new SubmissionController(fakeService, fakes.Mapper);
            var result = controller.GetHigherScore(challengeId);
            
            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value;
            Assert.IsType<decimal>(actual);
            Assert.Equal(expected, (decimal)actual);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(3,3)]
        public void Should_Be_Ok_When_Find_By_Challenge_And_Acceleration(int challengeId, int accelerationId)
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeSubmissionService().Object;
            var expected = fakeService.FindByChallengeIdAndAccelerationId(challengeId, accelerationId).
                Select(x => fakes.Mapper.Map<SubmissionDTO>(x)).
                ToList();

            var controller = new SubmissionController(fakeService, fakes.Mapper);
            var result = controller.GetAll(challengeId: challengeId, accelerationId: accelerationId);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<SubmissionDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new SubmissionDTOIdComparer());             
        }
    
        [Fact]
        public void Should_Be_Ok_When_Post()
        {
            var fakes = new Fakes();   
            var fakeService = fakes.FakeSubmissionService().Object;
            var expected = new SubmissionDTO() {
                UserId = 2, 
                ChallengeId = 6,
                Score = 90
            };

            var controller = new SubmissionController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as SubmissionDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected.UserId, actual.UserId);
            Assert.Equal(expected.ChallengeId, actual.ChallengeId);
            Assert.Equal(expected.Score, actual.Score);
        }

    }
}
