using MyLetterBoxd.Models;
using MyLetterBoxd.DTO;
using MyLetterBoxd.Database;
using Microsoft.EntityFrameworkCore;

namespace MyLetterBoxd.Service
{
    public class UserService
    {
        private readonly MyLetterBoxdContext _context;

        public UserService(MyLetterBoxdContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                // Username already exists
                return false;
            }

            var user = new User
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> LoginUserAsync(LoginRequest request)
        {
            var user = await _context.Users
                                    .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || !user.Password.Equals(request.Password))
            {
                // Invalid username or password
                return null;
            }

            return user;
        }
    }
}