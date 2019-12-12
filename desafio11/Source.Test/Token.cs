namespace Codenation.Challenge
{
    public class Token
    {
        public string access_token { get; set; }
        public long expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}