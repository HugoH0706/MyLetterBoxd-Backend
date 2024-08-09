using MyLetterBoxd.Database;
using MyLetterBoxd.DTO;
using MyLetterBoxd.Models;

namespace MyLetterBoxd.Service
{
    public class EntertainmentService
    {
        private readonly MyLetterBoxdContext _context;

        public EntertainmentService(MyLetterBoxdContext context)
        {
            _context = context;
        }

        public List<EntertainmentRequest> GetAllFilms()
        {
            var films = _context.Set<Film>()
                            .Select(f => new EntertainmentRequest
                            {
                                ID = f.ID,
                                Title = f.Title
                            })
                            .ToList();
            return films;
        }

        public Entertainment GetFilmById(int id)
        {
            var film = _context.Set<Film>()
                            .Where(film => film.ID == id)
                            .FirstOrDefault();
            return film;
        }
    }
}

