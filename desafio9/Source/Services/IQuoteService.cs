
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public interface IQuoteService
    {
        Quote GetAnyQuote();
        Quote GetAnyQuote(string actor);
    }
}
