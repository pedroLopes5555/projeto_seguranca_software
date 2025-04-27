namespace OAuthServer.API.ModelsRequest
{
    public class OAuthRequest
    {
        public required string response_type { get; set; }
        public required Guid client_id { get; set; }
        public required string redirect_uri { get; set; }
        public required string state { get; set; }
    }
}
