using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using OAuthServer.Repository.Key;

namespace OAuthServer.Services.Key
{
    public class KeyService : IKeyService
    {
        private readonly IKeyRepository _keyRepository;

        public KeyService(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
        }

        public byte[] GetPublicKey()
        {
            return _keyRepository.GetPublicKey();
        }

        public byte[] GetPrivateKey()
        {
            return _keyRepository.GetPrivateKey();
        }

        public RSA GetKey()
        {
            return _keyRepository.GetKey();
        }
    }
}