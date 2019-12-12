using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Services;
using Xunit;

namespace Codenation.Challenge
{
    public class RandomServiceTest
    {
        [Fact]
        public void Should_Generate_Random_Number_When_Get_Random_Integer()
        {
            var service = new RandomService();
            var numbers = new List<int>();
            for(var i = 0; i < 100; i++)
                numbers.Add(service.RandomInteger(50));
            Assert.True(numbers.Sum() / numbers[0] != numbers.Count);
        }

    }

}