using System.Linq;
using MovieDatabase.Data;
using MovieDatabase.Models;

namespace MovieDatabase.Services
{
    public class MovieService
    {
        private readonly MoviesDbContext _context;

        public MovieService(MoviesDbContext context)
        {
            _context = context;
        }

        public decimal GetAverageRatingByGenre(string genre)
        {
            var averageRating = _context.Movies
                .Where(m => m.Genre.ToLower() == genre.ToLower())
                .Average(m => (decimal?)m.Rating) ?? 0;

            return averageRating;
        }

    }
}
