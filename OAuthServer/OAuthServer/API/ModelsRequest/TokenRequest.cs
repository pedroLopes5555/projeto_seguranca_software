namespace OAuthServer.API.ModelsRequest;

public class TokenRequest
{
    public required Guid Grant { get; set; }
    public required string RedirectUri { get; set; }
    public required Guid ClientId { get; set; }
    public required string ClientSecret { get; set; }
}