using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class StudentLecturerRepository
    {
        public void Add(StudentLecturer model)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO StudentLecturer (StudentID, LecturerID) VALUES (@student, @lecturer)";
                cmd.Parameters.AddWithValue("@student", model.StudentID);
                cmd.Parameters.AddWithValue("@lecturer", model.LecturerID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StudentLecturer> GetAll()
        {
            var list = new List<StudentLecturer>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM StudentLecturer";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudentLecturer
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            LecturerID = Convert.ToInt32(reader["LecturerID"])
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
                cmd.CommandText = "DELETE FROM StudentLecturer WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}