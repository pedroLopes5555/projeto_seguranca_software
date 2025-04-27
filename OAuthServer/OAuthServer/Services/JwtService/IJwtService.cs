namespace OAuthServer.Services.JwtService;

public interface IJwtService
{
    Task<string> GenerateToken(Guid grant, string redirectUri, Guid clientId, string clientSecret);
}