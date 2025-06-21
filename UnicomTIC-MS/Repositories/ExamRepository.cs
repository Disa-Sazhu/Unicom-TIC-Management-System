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
    public class ExamRepository
    {
        public void Add(Exam exam)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Exams (ExamName, SubjectID) VALUES (@ExamName, @SubjectID)";
                cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                cmd.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Exam> GetAll()
        {
            var exams = new List<Exam>();

            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Exams";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamID = Convert.ToInt32(reader["ExamID"]),
                            ExamName = reader["ExamName"].ToString(),
                            SubjectID = Convert.ToInt32(reader["SubjectID"])
                        });
                    }
                }
            }

            return exams;
        }

        public void Delete(int examId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Exams WHERE ExamID = @id";
                cmd.Parameters.AddWithValue("@id", examId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Exam exam)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Exams SET ExamName = @name, SubjectID = @subId WHERE ExamID = @id";
                cmd.Parameters.AddWithValue("@name", exam.ExamName);
                cmd.Parameters.AddWithValue("@subId", exam.SubjectID);
                cmd.Parameters.AddWithValue("@id", exam.ExamID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}