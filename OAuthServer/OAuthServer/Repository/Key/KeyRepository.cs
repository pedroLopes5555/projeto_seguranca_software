using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace OAuthServer.Repository.Key
{
    public class KeyRepository : IKeyRepository
    {
        private readonly RSA _rsaKey;

        public KeyRepository()
        {
            _rsaKey = RSA.Create(2048);
        }

        public RSA GetKey()
        {
            return _rsaKey;
        }

        public byte[] GetPublicKey()
        {
            return _rsaKey.ExportSubjectPublicKeyInfo();
        }

        public byte[] GetPrivateKey()
        {
            return _rsaKey.ExportRSAPrivateKey();
        }
    }
}