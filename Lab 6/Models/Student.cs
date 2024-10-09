namespace ConsoleAppDBBasics.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int SchoolGraduationYear { get; set; }
        public int EntranceExamScore { get; set; }

        public Student(string lastName, string gender, int schoolGraduationYear, int entranceExamScore)
        {
            LastName = lastName;
            Gender = gender;
            SchoolGraduationYear = schoolGraduationYear;
            EntranceExamScore = entranceExamScore;
        }
    }
}
