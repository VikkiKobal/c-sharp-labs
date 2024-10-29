using System;
using System.Collections.Generic;
using System.Linq;
using MovieDatabase.Data;
using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new MoviesDbContext();

            context.Database.EnsureCreated();

            var movieService = new MovieService(context);
            var movieXmlSerializer = new MovieXmlSerializer(); 

            string genre = "Drama";
            decimal averageRating = movieService.GetAverageRatingByGenre(genre);
            Console.WriteLine($"Середній рейтинг жанру {genre}: {Math.Round(averageRating, 2)}");

            try
            {
                movieXmlSerializer.SaveMoviesToXml(context.Movies.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка при збереженні у файл: {ex.Message}");
            }

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadLine();
        }
    }
}
