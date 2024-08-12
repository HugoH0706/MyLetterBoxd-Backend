using Microsoft.AspNetCore.Mvc;
using MyLetterBoxd.Models;
using MyLetterBoxd.Service;
using MyLetterBoxd.DTO;
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

        [HttpGet("castentertainment/{id}")]
        public IActionResult FetchCastEntertainment([FromRoute] int id)
        {
            var castentertainment = _entertainmentService.GetCastByEntertainmentId(id);
            var cast = new List<CastRequest>();

            foreach(var ce in castentertainment)
            {
                CastRequest cr = _entertainmentService.GetCastById(ce.CastID);
                cast.Add(cr);
            }

    	    return Ok(cast);
        }

        [HttpGet("genresentertainment/{id}")]
        public IActionResult FetchGenresEntertainment([FromRoute] int id)
        {
            var genresentertainment = _entertainmentService.GetGenresByEntertainmentId(id);
            var genres = new List<string>();

            foreach(var ge in genresentertainment)
            {
                Genre genre = _entertainmentService.GetGenreById(ge.GenreID);
                genres.Add(genre.Name);
            }

    	    return Ok(genres);
        }
        
    }
}