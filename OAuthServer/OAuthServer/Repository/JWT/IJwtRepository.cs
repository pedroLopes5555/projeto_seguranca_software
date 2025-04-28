using OAuthServer.Repository.JWT;

namespace OAuthServer.Repository.JWT;

public interface IJwtRepository
{
    TokenResponse GenerateToken(string userId, string clientId);
}