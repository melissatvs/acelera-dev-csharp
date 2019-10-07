using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CountryTest
    {

        [Fact]
        public void Should_Return_10_Itens_When_Get_Top_10_States()
        {            
            var states = new Country();
            var top = states.Top10StatesByArea();
            Assert.NotNull(top);
            Assert.Equal(10, top.Length);
            
        }


        [Fact]
        public void DezPrimeirosEstados()
        {
            var states = new Country();
            var top = states.Top10StatesByArea();
            
            Assert.Equal("AM", top[0].Acronym);
            Assert.Equal("PA", top[1].Acronym);
            Assert.Equal("MT", top[2].Acronym);
            Assert.Equal("MG", top[3].Acronym);
            Assert.Equal("BA", top[4].Acronym);
            Assert.Equal("MS", top[5].Acronym);
            Assert.Equal("GO", top[6].Acronym);
            Assert.Equal("MA", top[7].Acronym);
            Assert.Equal("RS", top[8].Acronym);
            Assert.Equal("TO", top[9].Acronym);

        }
    }
}
