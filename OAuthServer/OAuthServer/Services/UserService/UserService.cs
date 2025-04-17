using OAuthServer.Repository.ModelsDB;
using OAuthServer.Repository.UserRepo;
using OAuthServer.Services.ModelsDTO;

namespace OAuthServer.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task<UserDTO> CreateUserAsync(string username, string password)
        {
            // make verifications and hash password later

            var dbUser = new UserDB
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = password,
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
    }
}
