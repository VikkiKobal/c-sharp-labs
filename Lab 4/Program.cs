using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\path\to\your\Vstup.json";

            // Створюємо JSON файл з початковими даними
            CreateJsonFile(filePath);

            // Виведення файлу на консолі
            Console.WriteLine("Вміст файлу Vstup.json:");
            DisplayJsonFile(filePath);

            // Запит прізвища для пошуку
            Console.Write("Введіть прізвище для пошуку: ");
            string surname = Console.ReadLine();
            DisplayEntrantBySurname(filePath, surname);

            // Запит для фільтру за роком та балами
            Console.Write("Введіть рік закінчення школи (X): ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть мінімальний сумарний бал (Y): ");
            int minScore = Convert.ToInt32(Console.ReadLine());

            CountEntrantsByYearAndScore(filePath, year, minScore);

            Console.ReadKey();
        }

        // Метод для створення початкового JSON файлу
        static void CreateJsonFile(string filePath)
        {
            var entrants = new List<Entrant>
            {
                new Entrant { Surname = "Ivanov", Gender = "Чоловіча", YearOfGraduation = 2020, EntranceScore = 190 },
                new Entrant { Surname = "Petrenko", Gender = "Жіноча", YearOfGraduation = 2021, EntranceScore = 180 },
                new Entrant { Surname = "Sydorenko", Gender = "Чоловіча", YearOfGraduation = 2019, EntranceScore = 170 }
            };

            string json = JsonConvert.SerializeObject(entrants, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // Метод для перегляду JSON файлу на консолі
        static void DisplayJsonFile(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            Console.WriteLine(jsonContent);
        }

        // Метод для пошуку абітурієнта за прізвищем
        static void DisplayEntrantBySurname(string filePath, string surname)
        {
            string jsonContent = File.ReadAllText(filePath);
            var entrants = JsonConvert.DeserializeObject<List<Entrant>>(jsonContent);

            var entrant = entrants.Find(e => e.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            if (entrant != null)
            {
                Console.WriteLine($"\nІнформація про абітурієнта {surname}:");
                Console.WriteLine($"Стать: {entrant.Gender}");
                Console.WriteLine($"Рік закінчення школи: {entrant.YearOfGraduation}");
                Console.WriteLine($"Сумарний бал на вступних екзаменах: {entrant.EntranceScore}");
            }
            else
            {
                Console.WriteLine($"Абітурієнта з прізвищем {surname} не знайдено.");
            }
        }

        // Метод для підрахунку абітурієнтів за роком закінчення школи та балами
        static void CountEntrantsByYearAndScore(string filePath, int year, int minScore)
        {
            string jsonContent = File.ReadAllText(filePath);
            var entrants = JsonConvert.DeserializeObject<List<Entrant>>(jsonContent);

            int count = entrants.FindAll(e => e.YearOfGraduation == year && e.EntranceScore >= minScore).Count;

            Console.WriteLine($"\nКількість абітурієнтів, які закінчили школу в {year} і набрали не менше {minScore} балів: {count}");
        }
    }
}
