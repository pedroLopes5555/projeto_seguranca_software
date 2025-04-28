using OAuthServer.Services.Key;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace OAuthServer.Repository.JWT
{
    public class JwtRepository : IJwtRepository
    {
        private readonly IKeyService _keyService;
        //logger
        private readonly ILogger<JwtRepository> _logger;
        public JwtRepository(IKeyService keyService, ILogger<JwtRepository> logger)
        {
            _logger = logger;
            _keyService = keyService;
        }
        
        public TokenResponse GenerateToken(string userId, string clientId)
        {
            var privateKey = new RsaSecurityKey(_keyService.GetKey());
            var creds = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);
            _logger.LogInformation("Generate token with clientId: {clientId}", clientId);
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, "OAuthServer"), // Issuer
                new Claim(JwtRegisteredClaimNames.Aud, clientId)  // Audience
            };
            _logger.LogInformation("Generate token with clientId: {clientId}", clientId);

            var token = new JwtSecurityToken(
                issuer: "OAuthServer",
                audience: clientId,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),  // Default token expiry
                signingCredentials: creds
            );
            _logger.LogInformation("Generate token with clientId: {clientId}", clientId);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            _logger.LogInformation("Generate token with clientId: {clientId}", clientId);

            // Generate refresh token (using a helper method to create it)
            string refreshToken = GenerateRefreshToken();

            _logger.LogInformation("Generate token with clientId: {clientId}", clientId);
            
            //log the token response
            
            return new TokenResponse
            {
                access_token = accessToken,
                token_type= "Bearer",
                expires_in= 3600, // 1 hour
                refresh_token = refreshToken
            };
            
        }

        // Generate a refresh token (typically a long-lived token)
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();  // Simple refresh token for example purposes
        }
    }


}
