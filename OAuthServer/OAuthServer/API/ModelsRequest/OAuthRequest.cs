namespace OAuthServer.API.ModelsRequest
{
    public class OAuthRequest
    {
        public required string ResponseType { get; set; }
        public required Guid ClientId { get; set; }
        public required string RedirectUri { get; set; }
        public required string State { get; set; }
    }
}
