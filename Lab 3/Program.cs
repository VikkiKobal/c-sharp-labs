using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFile = @"D:\.net labs\vstup.xml";

            StudentHandler.CreateXmlFile(xmlFile);
            StudentHandler.DisplayAllStudents(xmlFile);

            Console.WriteLine("Введіть прізвище для пошуку:");
            string surnameToFind = Console.ReadLine();
            StudentHandler.DisplayStudentBySurname(xmlFile, surnameToFind);

            Console.WriteLine("Введіть рік закінчення школи:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть мінімальний сумарний бал:");
            int score = int.Parse(Console.ReadLine());
            StudentHandler.DisplayStudentsByYearAndScore(xmlFile, year, score);
        }
    }
}
