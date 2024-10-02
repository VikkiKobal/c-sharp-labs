using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace Lab_3
{
    public static class StudentHandler
    {
        public static void DisplayAllStudents(List<Student> students)
        {
            StringBuilder str = new StringBuilder();
            foreach (var student in students)
            {
                str.AppendFormat("<h3>Student ID: {0}</h3>", student.Id);
                str.AppendFormat(@"<ul>
                <li>Прізвище: {0}</li>
                <li>Стать: {1}</li>
                <li>Рік закінчення школи: {2}</li>
                <li>Сумарний бал на вступних іспитах: {3}</li>
                </ul>", student.Surname, student.Gender, student.GraduationYear, student.EntranceScore);
            }
            Console.WriteLine(str.ToString());
        }

        public static void DisplayStudentBySurname(List<Student> students, string surname)
        {
            var student = students.FirstOrDefault(s => s.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            if (student != null)
            {
                Console.WriteLine($"Прізвище: {student.Surname}, Стать: {student.Gender}, Рік закінчення школи: {student.GraduationYear}, Сумарний бал: {student.EntranceScore}");
            }
            else
            {
                Console.WriteLine($"Абітурієнт з прізвищем {surname} не знайдений.");
            }
        }

        public static void DisplayStudentsByYearAndScore(List<Student> students, int year, int score)
        {
            var filteredStudents = students.Where(s => s.GraduationYear == year && s.EntranceScore >= score).ToList();
            Console.WriteLine($"Кількість абітурієнтів, які закінчили школу у {year} році і набрали не менше {score} балів: {filteredStudents.Count}");
        }
    }
}
