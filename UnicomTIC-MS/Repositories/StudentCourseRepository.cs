using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class StudentCourseRepository
    {
        public void Add(StudentCourse model)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO StudentCourse (StudentID, CourseID) VALUES (@student, @course)";
                cmd.Parameters.AddWithValue("@student", model.StudentID);
                cmd.Parameters.AddWithValue("@course", model.CourseID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StudentCourse> GetAll()
        {
            var list = new List<StudentCourse>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM StudentCourse";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudentCourse
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"])
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(int id)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM StudentCourse WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}