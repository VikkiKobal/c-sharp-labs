using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleAppDBBasics.Models;

namespace ConsoleAppDBBasics.Data
{
    public class StudentsRepository
    {
        private readonly AppDbContext _context;

        public StudentsRepository(AppDbContext context)
        {
            _context = context;
        }

        // Метод для перегляду всіх абітурієнтів у консолі
        public void PrintAllStudents()
        {
            Console.WriteLine("Викликається метод PrintAllStudents."); 
            try
            {
                var students = _context.Students.ToList(); 

                if (!students.Any()) 
                {
                    Console.WriteLine("Не знайдено жодного студента.");
                    return;
                }

                foreach (var student in students)
                {
                    Console.WriteLine($"Id: {student.Id}, LastName: {student.LastName}, Gender: {student.Gender}, SchoolGraduationYear: {student.SchoolGraduationYear}, EntranceExamScore: {student.EntranceExamScore}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при отриманні студентів: " + ex.Message);
            }
        }

        // Метод для отримання інформації про абітурієнта за прізвищем
        public Student? GetByLastName(string lastName)
        {
            try
            {
                return _context.Students.FirstOrDefault(s => s.LastName == lastName); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при отриманні студента: " + ex.Message);
                return null; 
            }
        }

        // Метод для підрахунку кількості абітурієнтів за роком закінчення та мінімальним балом
        public int CountStudentsByGraduationYearAndScore(int year, int minScore)
        {
            try
            {
                return _context.Students.Count(s => s.SchoolGraduationYear == year && s.EntranceExamScore >= minScore);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при підрахунку студентів: " + ex.Message);
                return 0;
            }
        }
    }
}
