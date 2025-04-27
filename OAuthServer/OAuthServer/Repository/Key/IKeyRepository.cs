using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace OAuthServer.Repository.Key;


/// <summary>
/// this class is a provider for the key repository.
public interface IKeyRepository
{
    RSA GetKey();

    byte[] GetPublicKey();

    byte[] GetPrivateKey();

}