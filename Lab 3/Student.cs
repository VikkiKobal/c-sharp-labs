namespace Lab_3
{
    public class Student
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int GraduationYear { get; set; }
        public int EntranceScore { get; set; }

        public Student(string id, string surname, string gender, int graduationYear, int entranceScore)
        {
            Id = id;
            Surname = surname;
            Gender = gender;
            GraduationYear = graduationYear;
            EntranceScore = entranceScore;
        }
    }
}
