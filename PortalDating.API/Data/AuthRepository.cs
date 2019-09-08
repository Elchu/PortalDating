using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalDating.API.Models;
using PortalDating.API.Utils;

namespace PortalDating.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbContext;

        public AuthRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));

            if (user == null)
                return null;

            return AuthManager.VeryfiPasswordHash(user.PasswordHash, user.PasswordSalt, password) ? user : null;
        }

        public async Task<User> Register(User user, string password)
        {
            AuthManager.CreatePasswordHashSalt(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username.Equals(username)) ? true : false;
        }
    }
}
