using System.Collections.Generic;
using System;
using System.Xml;

namespace Lab_3
{
    public static class XmlHandler
    {
        public static void CreateXmlFile(string xmlFile, List<Student> students)
        {
            using (XmlTextWriter writer = new XmlTextWriter(xmlFile, null))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                writer.WriteStartDocument(true);
                writer.WriteStartElement("Students");

                foreach (var student in students)
                {
                    WriteStudent(writer, student);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine($"XML файл '{xmlFile}' створений.");
        }

        private static void WriteStudent(XmlTextWriter writer, Student student)
        {
            writer.WriteStartElement("student");
            writer.WriteAttributeString("ID", student.Id);
            writer.WriteElementString("Surname", student.Surname);
            writer.WriteElementString("Gender", student.Gender);
            writer.WriteElementString("GraduationYear", student.GraduationYear.ToString());
            writer.WriteElementString("EntranceScore", student.EntranceScore.ToString());
            writer.WriteEndElement();
        }

        public static List<Student> ReadStudents(string xmlFile)
        {
            List<Student> students = new List<Student>();
            using (XmlReader reader = XmlReader.Create(xmlFile))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "student")
                    {
                        var id = reader.GetAttribute("ID");
                        reader.ReadStartElement("student");
                        var surname = reader.ReadElementString("Surname");
                        var gender = reader.ReadElementString("Gender");
                        var graduationYear = int.Parse(reader.ReadElementString("GraduationYear"));
                        var entranceScore = int.Parse(reader.ReadElementString("EntranceScore"));

                        students.Add(new Student(id, surname, gender, graduationYear, entranceScore));
                    }
                }
            }
            return students;
        }
    }
}
