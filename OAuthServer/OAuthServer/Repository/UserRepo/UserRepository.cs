using Microsoft.EntityFrameworkCore;
using OAuthServer.Repository.Models;

namespace OAuthServer.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly OAuthContex _context;

        public UserRepository(OAuthContex context)
        {
            _context = context;
        }

        public async Task<DbUser?> CreateUser(DbUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<DbUser?> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<DbUser?> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }


        public async Task<DbUser?> UpdateUser(DbUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<DbUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
