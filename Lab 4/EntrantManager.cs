using System;
using System.Collections.Generic;


namespace Lab_4
{
    public class EntrantManager
    {
        private readonly List<Entrant> entrants;

        public EntrantManager(List<Entrant> entrants)
        {
            this.entrants = entrants;
        }

        public void DisplayAllEntrants()
        {
            foreach (var entrant in entrants)
            {
                Console.WriteLine($"{entrant.Surname}, {entrant.Gender}, {entrant.YearOfGraduation}, {entrant.EntranceScore}");
            }
        }

        public void DisplayEntrantBySurname(string surname)
        {
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

        public void CountEntrantsByYearAndScore(int year, int minScore)
        {
            int count = entrants.FindAll(e => e.YearOfGraduation == year && e.EntranceScore >= minScore).Count;
            Console.WriteLine($"\nКількість абітурієнтів, які закінчили школу в {year} і набрали не менше {minScore} балів: {count}");
        }
    }

}
