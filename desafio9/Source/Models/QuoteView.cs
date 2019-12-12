using Newtonsoft.Json;

namespace Codenation.Challenge.Models
{
    public class QuoteView
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("actor")]
        public string Actor { get; set; }

        [JsonProperty("quote")]
        public string Detail { get; set; }

    }
}