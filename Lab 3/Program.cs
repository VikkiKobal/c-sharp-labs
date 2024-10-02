using System.Collections.Generic;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFile = @"D:\.net labs\vstup.xml";

            List<Student> students = new List<Student>
            {
                new Student("1", "Петренко", "Чоловік", 2020, 180),
                new Student("2", "Мельничук", "Жінка", 2021, 195)
            };

            XmlHandler.CreateXmlFile(xmlFile, students);

            List<Student> loadedStudents = XmlHandler.ReadStudents(xmlFile);

            StudentHandler.DisplayAllStudents(loadedStudents);

            StudentHandler.DisplayStudentBySurname(loadedStudents, "Петренко");

            StudentHandler.DisplayStudentsByYearAndScore(loadedStudents, 2020, 170);
        }
    }
}
