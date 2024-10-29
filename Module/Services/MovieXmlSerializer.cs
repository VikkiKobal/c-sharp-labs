using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MovieDatabase.Models;

namespace MovieDatabase.Services
{
    public class MovieXmlSerializer
    {
        private readonly string _filePath;

        public MovieXmlSerializer(string filePath = @"D:\.net labs\Movies.xml")
        {
            _filePath = filePath;
        }

        public void SaveMoviesToXml(List<Movie> movies)
        {
            var serializer = new XmlSerializer(typeof(List<Movie>));
            try
            {
                using (var writer = new StreamWriter(_filePath))
                {
                    serializer.Serialize(writer, movies);
                }
                Console.WriteLine($"Дані фільмів були збережені в {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка при збереженні у файл: {ex.Message}");
            }
        }
    }
}
