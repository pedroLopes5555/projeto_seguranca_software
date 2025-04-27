using OAuthServer.Services.JWT;

namespace OAuthServer.Services.Jwt;

public class JwtService : IJwtService
{
    private readonly IJwtRepository _jwtRepository;
    
    public JwtService(IJwtRepository jwtRepository)
    {
        _jwtRepository = jwtRepository;
    }
    
    public async Task<string> GenerateToken(Guid grant, string redirectUri, Guid clientId, string clientSecret)
    {
        //TODO -> implement check logic
        return _jwtRepository.GenerateToken("teste", "TesteClientId");
    }
    
    
}