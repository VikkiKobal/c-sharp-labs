using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public decimal? Rating { get; set; }

        public Movie()
        {
            Title = string.Empty;
            Genre = string.Empty;
        }

        public Movie(string title, string genre, int releaseYear, decimal? rating = null)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            Rating = rating;
        }
    }
}
