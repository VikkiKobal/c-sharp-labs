using System;
using System.Text;
using System.Xml;

namespace Lab_3
{
    class Tasks
    {
        static void Main(string[] args)
        {
            string xmlFile = @"D:\.net labs\vstup.xml";

            CreateXmlFile(xmlFile);
            DisplayAllStudents(xmlFile);

            Console.WriteLine("Введіть прізвище для пошуку:");
            string surnameToFind = Console.ReadLine();
            DisplayStudentBySurname(xmlFile, surnameToFind);

            Console.WriteLine("Введіть рік закінчення школи:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть мінімальний сумарний бал:");
            int score = int.Parse(Console.ReadLine());
            DisplayStudentsByYearAndScore(xmlFile, year, score);
        }

        static void CreateXmlFile(string xmlFile)
        {
            using (XmlTextWriter writer = new XmlTextWriter(xmlFile, null))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                writer.WriteStartDocument(true);
                writer.WriteStartElement("Students");

                writer.WriteStartElement("student");
                writer.WriteAttributeString("ID", "1");
                writer.WriteElementString("Surname", "Петренко");
                writer.WriteElementString("Gender", "Чоловік");
                writer.WriteElementString("GraduationYear", "2020");
                writer.WriteElementString("EntranceScore", "180");
                writer.WriteEndElement();

                writer.WriteStartElement("student");
                writer.WriteAttributeString("ID", "2");
                writer.WriteElementString("Surname", "Мельничук");
                writer.WriteElementString("Gender", "Жінка");
                writer.WriteElementString("GraduationYear", "2021");
                writer.WriteElementString("EntranceScore", "195");
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("XML файл 'Vstup.xml' створений.");
        }

        static void DisplayAllStudents(string xmlFile)
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

        static void DisplayStudentBySurname(string xmlFile, string surname)
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

        static void DisplayStudentsByYearAndScore(string xmlFile, int year, int score)
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

            Console.WriteLine($"Кількість абітурієнтів, які закінчили школу у {year} році і набрали не менше {score} балів: {count}");
        }
    }
}
