using System;
using ConsoleAppDBBasics.Data;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            try
            {
                Console.WriteLine("Список усіх студентів:");
                var repository = new StudentsRepository(context);
                repository.PrintAllStudents();

                Console.Write("Введіть прізвище студента: ");
                string lastName = Console.ReadLine() ?? string.Empty; // Ensure lastName is not null
                var student = repository.GetByLastName(lastName);

                if (student != null)
                {
                    Console.WriteLine($"Студент: {student.LastName}, Стать: {student.Gender}, Рік закінчення: {student.SchoolGraduationYear}, Бал за вступ: {student.EntranceExamScore}");
                }
                else
                {
                    Console.WriteLine("Студента не знайдено.");
                }

                Console.Write("Введіть рік закінчення: ");
                if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
                {
                    Console.WriteLine("Невірний формат року.");
                    return; // Exit if parsing fails
                }

                Console.Write("Введіть мінімальний бал: ");
                if (!int.TryParse(Console.ReadLine(), out int minScore) || minScore < 0)
                {
                    Console.WriteLine("Невірний формат бала.");
                    return; // Exit if parsing fails
                }

                int count = repository.CountStudentsByGraduationYearAndScore(year, minScore);
                Console.WriteLine($"Кількість абітурієнтів, які закінчили школу в {year} році і набрали не менше {minScore} балів: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: " + ex.Message);
            }
        }

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey(); // Затримка до натискання клавіші
    }
}
