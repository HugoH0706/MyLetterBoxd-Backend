using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLetterBoxd.Database;
using MyLetterBoxd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLetterBoxd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyLetterBoxdContext _context;

        public UsersController(MyLetterBoxdContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Other CRUD actions (Post, Put, Delete)
    }
}
