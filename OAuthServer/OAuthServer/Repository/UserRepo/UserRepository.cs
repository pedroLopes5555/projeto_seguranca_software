using Microsoft.EntityFrameworkCore;
using OAuthServer.Repository.ModelsDB;

namespace OAuthServer.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly OAuthContex _context;

        public UserRepository(OAuthContex context)
        {
            _context = context;
        }

        public async Task<UserDB?> CreateUser(UserDB user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserDB?> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserDB?> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }


        public async Task<UserDB?> UpdateUser(UserDB user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<UserDB>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
