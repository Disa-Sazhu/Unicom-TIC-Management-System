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
    public class SubjectRepository
    {
        public void Add(Subject subject)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@name, @courseId)";
                cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Subject> GetAll()
        {
            var list = new List<Subject>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Subjects";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Subject
                        {
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            CourseID = Convert.ToInt32(reader["CourseID"])
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(int subjectId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Subjects WHERE SubjectID = @id";
                cmd.Parameters.AddWithValue("@id", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Subject subject)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Subjects SET SubjectName = @name, CourseID = @courseId WHERE SubjectID = @id";
                cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                cmd.Parameters.AddWithValue("@id", subject.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}