using MyLetterBoxd.Database;

namespace MyLetterBoxd.Service
{
    public class EntertainmentService
    {
        private readonly MyLetterBoxdContext _context;

        public EntertainmentService(MyLetterBoxdContext context)
        {
            _context = context;
        }

        // public async Task AddActorToFilmAsync(int filmId, string actor)
        // {
        //     var film = await _context.Films.FindAsync(filmId);

        //     if (film == null)
        //     {
        //         throw new ArgumentException("Film not found");
        //     }

        //     if (!film.Actors.Contains(actor))
        //     {
        //         film.Actors.Add(actor);
        //         await _context.SaveChangesAsync();
        //     }
        // }

        // public async Task AddDirectorToFilmAsync(int filmId, string director)
        // {
        //     var film = await _context.Films.FindAsync(filmId);

        //     if (film == null)
        //     {
        //         throw new ArgumentException("Film not found");
        //     }

        //     if (!film.Directors.Contains(director))
        //     {
        //         film.Directors.Add(director);
        //         await _context.SaveChangesAsync();
        //     }
        // }
    }
}

