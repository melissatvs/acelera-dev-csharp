using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Controllers;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Codenation.Challenge
{
    public class QuoteControllerTest
    {
        private Mock<ScriptsContext> fakeContext;
        private List<Quote> fakeData = new List<Quote>();

        public QuoteControllerTest()
        {
            fakeData.AddRange(new List<Quote>() {
                new Quote() { Id = 1, Actor = "Eric", Detail = "1" },
                new Quote() { Id = 2, Actor = "Eric", Detail = "2" },
                new Quote() { Id = 3, Actor = "Eric", Detail = "3" },
                new Quote() { Id = 4, Actor = "Terry", Detail = "Ni" },
                new Quote() { Id = 5, Actor = "Graham", Detail = "Ni" },
            });

            var fakeQuotes = fakeData.AsQueryable();
            
            var fakeDbSet = new Mock<DbSet<Quote>>();
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.Provider).Returns(fakeQuotes.Provider);
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.Expression).Returns(fakeQuotes.Expression);
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.ElementType).Returns(fakeQuotes.ElementType);
            fakeDbSet.As<IQueryable<Quote>>().Setup(x => x.GetEnumerator()).Returns(fakeQuotes.GetEnumerator());

            this.fakeContext = new Mock<ScriptsContext>();            
            this.fakeContext.Setup(x => x.Quotes).Returns(fakeDbSet.Object);
        }
    
        [Fact]
        public void Should_Returns_Not_Found_When_Get_Any_Quote_By_Non_Exists_Actor()
        {
            var fakeRandom = new Mock<IRandomService>();
            fakeRandom.Setup(x => x.RandomInteger(It.IsAny<int>())).Returns(0);
            var fakeService = new QuoteService(fakeContext.Object, fakeRandom.Object);
            var controller = new QuoteController(fakeService);

            var actual = controller.GetAnyQuote("Michael Palin");
            Assert.NotNull(actual);
            Assert.IsType<NotFoundResult>(actual.Result);
        }

    }
}
