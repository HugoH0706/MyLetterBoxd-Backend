using Microsoft.AspNetCore.Mvc;
using MyLetterBoxd.Models;
using MyLetterBoxd.Service;
using System.Threading.Tasks;

namespace MyLetterBoxd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntertainmentController : ControllerBase
    {
        private readonly EntertainmentService _entertainmentService;

        public EntertainmentController(EntertainmentService entertainmentService)
        {
            _entertainmentService = entertainmentService;
        }

        [HttpGet("films")]
        public IActionResult FetchFilms()
        {
            var films = _entertainmentService.GetAllFilms();
            return Ok(films);
        }

        [HttpGet("films/{id}")]
        public IActionResult FetchFilmById([FromRoute] int id)
        {
            var film = _entertainmentService.GetFilmById(id);
            if(film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }
        
    }
}