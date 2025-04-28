using OAuthServer.Repository.JWT;

namespace OAuthServer.Services.JwtService;

public interface IJwtService
{
    Task<TokenResponse> GenerateToken(Guid grant, string redirectUri, Guid clientId, string clientSecret);
}