using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace OAuthServer.Services.Key;

public interface IKeyService
{
    byte[] GetPublicKey();
    byte[] GetPrivateKey();

    RSA GetKey();
}