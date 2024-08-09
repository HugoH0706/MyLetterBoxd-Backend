using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLetterBoxd.Database;
using MyLetterBoxd.Models;
using MyLetterBoxd.DTO;
using MyLetterBoxd.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLetterBoxd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _userService.RegisterUserAsync(request);

            if (!result)
            {
                return BadRequest("Username is already taken.");
            }

            return Ok("User registered successfully.");
        }

        [HttpPost("userentertainment")]
        public async Task<IActionResult> Watchlist([FromBody] WatchlistRequest request)
        {
            await _userService.AddToWatchListAsync(request);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.LoginUserAsync(request);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(new { Message = "Login successful.", User = user }); // DTO maken om niet alle user info op te sturen
        }
    }
}
