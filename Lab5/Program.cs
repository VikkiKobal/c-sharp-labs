using System;
using Lab_5___ADO.NET.Data; 

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Server=DESKTOP-T94V6UV\SQLEXPRESS;Database=StudentsDB;Trusted_Connection=True;TrustServerCertificate=True";
        var repository = new StudentsRepository(connectionString);

        try
        {
            Console.WriteLine("Список усіх студентів:");
            var students = repository.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Студент: {student.LastName}, Стать: {student.Gender}, Рік закінчення: {student.SchoolGraduationYear}, Бал за вступ: {student.EntranceExamScore}");
            }

            Console.Write("Введіть прізвище студента: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            var studentFound = repository.GetByLastName(lastName);

            if (studentFound != null)
            {
                Console.WriteLine($"Студент: {studentFound.LastName}, Стать: {studentFound.Gender}, Рік закінчення: {studentFound.SchoolGraduationYear}, Бал за вступ: {studentFound.EntranceExamScore}");
            }
            else
            {
                Console.WriteLine("Студента не знайдено.");
            }

            Console.Write("Введіть рік закінчення: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
            {
                Console.WriteLine("Невірний формат року.");
                return; 
            }

            Console.Write("Введіть мінімальний бал: ");
            if (!int.TryParse(Console.ReadLine(), out int minScore) || minScore < 0)
            {
                Console.WriteLine("Невірний формат бала.");
                return;
            }

            int count = repository.CountStudentsByGraduationYearAndScore(year, minScore);
            Console.WriteLine($"Кількість абітурієнтів, які закінчили школу в {year} році і набрали не менше {minScore} балів: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
    }
}
