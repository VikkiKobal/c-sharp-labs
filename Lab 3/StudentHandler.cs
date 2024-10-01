using System;
using System.Text;
using System.Xml;

namespace Lab_3
{
    public static class StudentHandler
    {
        public static void DisplayAllStudents(string xmlFile)
        {
            StringBuilder str = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "student")
                    {
                        var id = reader.GetAttribute("ID");
                        reader.ReadStartElement("student");
                        str.AppendFormat("<h3>Student ID: {0}</h3>", id);
                        str.AppendFormat(@"<ul>
                        <li>Прізвище: {0}</li>
                        <li>Стать: {1}</li>
                        <li>Рік закінчення школи: {2}</li>
                        <li>Сумарний бал на вступних іспитах: {3}</li>
                        </ul>",
                            reader.ReadElementString("Surname"),
                            reader.ReadElementString("Gender"),
                            reader.ReadElementString("GraduationYear"),
                            reader.ReadElementString("EntranceScore"));
                    }
                }
            }
            Console.WriteLine(str.ToString());
        }

        public static void DisplayStudentBySurname(string xmlFile, string surname)
        {
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                bool studentFound = false;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "student")
                    {
                        reader.ReadStartElement("student");
                        string currentSurname = reader.ReadElementString("Surname");
                        string gender = reader.ReadElementString("Gender");
                        string year = reader.ReadElementString("GraduationYear");
                        string score = reader.ReadElementString("EntranceScore");

                        if (currentSurname.Equals(surname, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Прізвище: {currentSurname}, Стать: {gender}, Рік закінчення школи: {year}, Сумарний бал: {score}");
                            studentFound = true;
                            break;
                        }
                    }
                }

                if (!studentFound)
                {
                    Console.WriteLine($"Абітурієнт з прізвищем {surname} не знайдений.");
                }
            }
        }

        public static void DisplayStudentsByYearAndScore(string xmlFile, int year, int score)
        {
            int count = 0;
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "student")
                    {
                        reader.ReadStartElement("student");
                        reader.ReadElementString("Surname");
                        reader.ReadElementString("Gender");
                        int gradYear = int.Parse(reader.ReadElementString("GraduationYear"));
                        int entranceScore = int.Parse(reader.ReadElementString("EntranceScore"));

                        if (gradYear == year && entranceScore >= score)
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine($"Кількість абітурієнтів, які закінчили школу у {year} році і набрали не менше {score}
