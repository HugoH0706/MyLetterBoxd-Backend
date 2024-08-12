using MyLetterBoxd.Database;
using MyLetterBoxd.DTO;
using MyLetterBoxd.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<UserEntertainment> GetEntertainmentByUserId(int id)
        {
            var userEntertainment = _context.Set<UserEntertainment>()
                            .Where(ue => ue.UserID == id)
                            .ToList();
            return userEntertainment;
        }

        public List<CastEntertainment> GetCastByEntertainmentId(int id)
        {
            var castentertainment = _context.Set<CastEntertainment>()
                            .Where(ce => ce.EntertainmentID == id)
                            .ToList();
            return castentertainment;
        }

        public CastRequest GetCastById(int id)
        {
            var cast = _context.Set<Cast>()
                            .Where(c => c.ID == id)
                            .Select(c => new CastRequest
                            {
                                Name = c.Name,
                                Character = c.Character   
                            })
                            .FirstOrDefault();
            return cast;
        }
        public List<GenreEntertainment> GetGenresByEntertainmentId(int id)
        {
            var genresentertainment = _context.Set<GenreEntertainment>()
                            .Where(ge => ge.EntertainmentID == id)
                            .ToList();
            return genresentertainment;
        }

        public Genre GetGenreById(int id)
        {
            var genre = _context.Set<Genre>()
                            .Where(genre => genre.ID == id)
                            .FirstOrDefault();
            return genre;
        }

        public Entertainment GetFilmById(int id)
        {
            var film = _context.Set<Film>()
                            .Where(film => film.ID == id)
                            .FirstOrDefault();
            return film;
        }

        public async Task<bool> RemoveEntertainmentFromList(int userId, int entertainmentId)
        {
            var userEntertainment = await _context.UserEntertainments
                .FirstOrDefaultAsync(ue => ue.UserID == userId && ue.EntertainmentID == entertainmentId);
            Console.WriteLine("Hello2");
            if (userEntertainment == null)
            {
                return false;
            }
            Console.WriteLine("Hello");
            _context.UserEntertainments.Remove(userEntertainment);
            await _context.SaveChangesAsync();  
            return true;
        }
    }
}

