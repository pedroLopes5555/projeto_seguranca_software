namespace OAuthServer.Services.JWT;

public interface IJwtRepository
{
    string GenerateToken(string userId, string clientId);
}