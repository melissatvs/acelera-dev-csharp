using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;
        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            try
            {
                Quote quote = _service.GetAnyQuote();

                if (quote == null)
                {
                    return NotFound();
                }

                QuoteView quoteView = new QuoteView();

                quoteView.Id = quote.Id;
                quoteView.Actor = quote.Actor;
                quoteView.Detail = quote.Detail;

                return quoteView;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            try
            {
                Quote quote = _service.GetAnyQuote(actor);                

                if (quote == null)
                {
                    return NotFound();
                }

                QuoteView quoteView = new QuoteView();

                quoteView.Id = quote.Id;
                quoteView.Actor = quote.Actor;
                quoteView.Detail = quote.Detail;

                return quoteView;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
