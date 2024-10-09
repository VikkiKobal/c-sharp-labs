using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Lab_5___ADO.NET_.Models;

namespace Lab_5___ADO.NET.Data
{
    public class StudentsRepository
    {
        private readonly string _connectionString;

        public StudentsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Students", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = (int)reader["Id"],
                            LastName = reader["LastName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            SchoolGraduationYear = (int)reader["SchoolGraduationYear"],
                            EntranceExamScore = (int)reader["EntranceExamScore"]
                        });
                    }
                }
            }
            return students;
        }

        public Student GetByLastName(string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Students WHERE LastName = @LastName", connection);
                command.Parameters.AddWithValue("@LastName", lastName);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            Id = (int)reader["Id"],
                            LastName = reader["LastName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            SchoolGraduationYear = (int)reader["SchoolGraduationYear"],
                            EntranceExamScore = (int)reader["EntranceExamScore"]
                        };
                    }
                }
            }
            return null;
        }

        public int CountStudentsByGraduationYearAndScore(int year, int minScore)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Students WHERE SchoolGraduationYear = @Year AND EntranceExamScore >= @MinScore", connection);
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@MinScore", minScore);
                return (int)command.ExecuteScalar();
            }
        }
    }
}
