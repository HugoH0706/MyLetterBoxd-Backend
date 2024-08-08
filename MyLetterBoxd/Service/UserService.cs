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

        public async Task AddToWatchListAsync(WatchlistRequest request)
        {
            var userEntertainment = new UserEntertainment
            {
                UserID = request.UserID,
                EntertainmentID = request.EntertainmentID
            };
            await SaveUserEntertainmentAsync(userEntertainment);
        }

        public async Task SaveUserEntertainmentAsync(UserEntertainment ue)
        {
            var existingUE = await _context.UserEntertainments
                .FirstOrDefaultAsync(e => e.UserID == ue.UserID && e.EntertainmentID == ue.EntertainmentID);

            if(existingUE != null)
            {
                Console.WriteLine("Already added to your watchlist");
            }
            else 
            {
                _context.Add(ue);
                await _context.SaveChangesAsync();
            }
        }
    }
}