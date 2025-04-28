namespace OAuthServer.API.ModelsRequest;

public class LoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string ResponseType { get; set; }
    public required Guid ClientId { get; set; }
    public required string RedirectUri { get; set; }
}
