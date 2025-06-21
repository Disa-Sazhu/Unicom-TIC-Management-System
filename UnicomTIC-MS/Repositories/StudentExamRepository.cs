using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;
namespace UnicomTIC_MS.Repositories
{
    public class StudentExamRepository
    {
        public void Add(StudentExam model)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO StudentExam (StudentID, ExamID) VALUES (@student, @exam)";
                cmd.Parameters.AddWithValue("@student", model.StudentID);
                cmd.Parameters.AddWithValue("@exam", model.ExamID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StudentExam> GetAll()
        {
            var list = new List<StudentExam>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM StudentExam";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudentExam
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            ExamID = Convert.ToInt32(reader["ExamID"])
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
                cmd.CommandText = "DELETE FROM StudentExam WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}