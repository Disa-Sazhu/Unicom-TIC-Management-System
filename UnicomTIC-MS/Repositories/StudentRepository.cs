using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class StudentRepository
    {
        public void Add(Student student)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Students 
                    (FirstName, LastName, Age, Email, NIC, Gender, Course, Role)
                    VALUES (@FirstName, @LastName, @Age, @Email, @NIC, @Gender, @Course, @Role)";

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@NIC", student.NIC);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@Role", student.Role);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetAll()
        {
            var list = new List<Student>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Students";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Email = reader["Email"].ToString(),
                            NIC = reader["NIC"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Course = reader["Course"].ToString(),
                            Role = reader["Role"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(int studentId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Students WHERE StudentID = @id";
                cmd.Parameters.AddWithValue("@id", studentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Student student)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Students SET 
                    FirstName = @FirstName,
                    LastName = @LastName,
                    Age = @Age,
                    Email = @Email,
                    NIC = @NIC,
                    Gender = @Gender,
                    Course = @Course,
                    Role = @Role
                    WHERE StudentID = @StudentID";

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@NIC", student.NIC);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@Role", student.Role);
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

