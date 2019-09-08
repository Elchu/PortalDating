using System.Text;
using System.Threading.Tasks;
using PortalDating.API.Models;

namespace PortalDating.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbContext;

        public AuthRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHashSalt(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }

        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.Key;
                passwordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}