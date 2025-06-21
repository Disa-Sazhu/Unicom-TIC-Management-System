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
    public class CourseRepository
    {
        public void Add(Course course)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Courses (CourseName) VALUES (@CourseName)";
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Course> GetAll()
        {
            var list = new List<Course>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Courses";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Course
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(int courseId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Courses WHERE CourseID = @id";
                cmd.Parameters.AddWithValue("@id", courseId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Course course)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Courses SET CourseName = @name WHERE CourseID = @id";
                cmd.Parameters.AddWithValue("@name", course.CourseName);
                cmd.Parameters.AddWithValue("@id", course.CourseID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}