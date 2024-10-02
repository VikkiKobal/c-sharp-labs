using Lab_4;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"D:\.net labs\vstup.json";

        var entrants = new List<Entrant>
            {
                new Entrant { Surname = "Ivanov", Gender = "Чоловіча", YearOfGraduation = 2020, EntranceScore = 190 },
                new Entrant { Surname = "Petrenko", Gender = "Жіноча", YearOfGraduation = 2021, EntranceScore = 180 },
                new Entrant { Surname = "Sydorenko", Gender = "Чоловіча", YearOfGraduation = 2019, EntranceScore = 170 }
            };

        JsonFileHandler.CreateJsonFile(filePath, entrants);

        Console.WriteLine("Вміст файлу Vstup.json:");
        string jsonContent = JsonFileHandler.ReadJsonFile(filePath);
        Console.WriteLine(jsonContent);

        var entrantManager = new EntrantManager(entrants);

        Console.Write("Введіть прізвище для пошуку: ");
        string surname = Console.ReadLine();
        entrantManager.DisplayEntrantBySurname(surname);

        Console.Write("Введіть рік закінчення школи (X): ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введіть мінімальний сумарний бал (Y): ");
        int minScore = Convert.ToInt32(Console.ReadLine());

        entrantManager.CountEntrantsByYearAndScore(year, minScore);
    }
}
