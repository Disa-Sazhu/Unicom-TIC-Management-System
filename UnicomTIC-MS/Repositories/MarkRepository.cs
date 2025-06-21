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
    public class MarkRepository
    {
        public void Add(Mark mark)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Marks (StudentID, ExamID, Score) VALUES (@StudentID, @ExamID, @Score)";
                cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                cmd.Parameters.AddWithValue("@Score", mark.Score);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Mark> GetAll()
        {
            var list = new List<Mark>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Marks";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Mark
                        {
                            MarkID = Convert.ToInt32(reader["MarkID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            ExamID = Convert.ToInt32(reader["ExamID"]),
                            Score = Convert.ToInt32(reader["Score"])
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(int markId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Marks WHERE MarkID = @id";
                cmd.Parameters.AddWithValue("@id", markId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Mark mark)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Marks SET StudentID = @StudentID, ExamID = @ExamID, Score = @Score WHERE MarkID = @id";
                cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                cmd.Parameters.AddWithValue("@Score", mark.Score);
                cmd.Parameters.AddWithValue("@id", mark.MarkID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
