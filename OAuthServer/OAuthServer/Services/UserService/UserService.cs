using OAuthServer.Exeptions;
using OAuthServer.Repository.ModelsDB;
using OAuthServer.Repository.UserRepo;
using OAuthServer.Services.AuthorizationService;
using OAuthServer.Services.CookieService;
using OAuthServer.Services.Hash;
using OAuthServer.Services.ModelsDTO;

namespace OAuthServer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasher _hasher;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICookieService _cookieService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserRepository userRepository, IHasher hasher, IAuthorizationService authorizationService, ICookieService cookieService, IHttpContextAccessor httpContextAccessor) 
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _authorizationService = authorizationService;
            _cookieService = cookieService;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc />
        public async Task<UserDTO> CreateUserAsync(string username, string password)
        {
            if (username == "" || password == "")
                throw new Exception("Invalid fields");

            var passwordHashed = _hasher.GetStringHashed(password);

            var dbUser = new UserDB
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = passwordHashed,
            };

            var createdUser = await _userRepository.CreateUser(dbUser);

            if (createdUser == null)
                throw new Exception("Could not Create User");
            return new UserDTO
            {
                Id = createdUser.Id.ToString(),
                Username = createdUser.Username,
            };
        }

        /// <inheritdoc />
        public async Task<String> LoginAsync(
            string username, 
            string password,
            string responseType,
            Guid clientId,
            string redirectUri,
            string state
        )
        {
            if (username == "" || password == "")
                throw new InvalidInputException("Invalid fields");

            var dbUser = await _userRepository.GetUserByUsername(username);

            if (dbUser == null)
                throw new Exception("No user found");

            if(!_hasher.VerifyText(dbUser.PasswordHash, password))
                throw new Exception("Invalid password");


            await _cookieService.CreateAuthenticationCookieAsync(
                _httpContextAccessor.HttpContext ?? throw new Exception("Http context is null"),
                dbUser.Id,
                dbUser.Username
            );


            return await _authorizationService.GenerateAuthorizationCodeRedirectUriAsync(clientId, redirectUri, state);
        }
    }
}
