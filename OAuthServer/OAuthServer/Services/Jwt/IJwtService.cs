namespace OAuthServer.Services.Jwt;

public interface IJwtService
{
    Task<string> GenerateToken(Guid grant, string redirectUri, Guid clientId, string clientSecret);
}