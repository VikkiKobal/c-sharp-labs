using System.Xml;

namespace Lab_3
{
    public static class StudentRepository
    {
        public static void CreateXmlFile(string xmlFile)
        {
            using (XmlTextWriter writer = new XmlTextWriter(xmlFile, null))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                writer.WriteStartDocument(true);
                writer.WriteStartElement("Students");

                WriteStudent(writer, new Student("1", "Петренко", "Чоловік", 2020, 180));
                WriteStudent(writer, new Student("2", "Мельничук", "Жінка", 2021, 195));

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine($"XML файл '{xmlFile}' створений.");
        }

        private static void WriteStudent(XmlTextWriter writer, Student student)
        {
            writer.WriteStartElement("student");
            writer.WriteAttributeString("ID", student.ID);
            writer.WriteElementString("Surname", student.Surname);
            writer.WriteElementString("Gender", student.Gender);
            writer.WriteElementString("GraduationYear", student.GraduationYear.ToString());
            writer.WriteElementString("EntranceScore", student.EntranceScore.ToString());
            writer.WriteEndElement();
        }
    }
}
