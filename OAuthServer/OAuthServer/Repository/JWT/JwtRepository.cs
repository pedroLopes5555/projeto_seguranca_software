using OAuthServer.Services.Key;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace OAuthServer.Services.JWT
{
    public class JwtRepository : IJwtRepository
    {
        private readonly IKeyService _keyService;
        
        
        public JwtRepository(IKeyService keyService)
        {
            _keyService = keyService;
        }
        
        
        public string GenerateToken(string userId, string clientId)
        {
            var privateKey = new RsaSecurityKey(_keyService.GetKey());
            var creds = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "OAuthServer",
                audience: clientId,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}