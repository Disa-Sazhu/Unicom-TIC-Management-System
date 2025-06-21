using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class StudentSectionRepository
    {
        public void Add(StudentSection model)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO StudentSection (StudentID, SectionID) VALUES (@student, @section)";
                cmd.Parameters.AddWithValue("@student", model.StudentID);
                cmd.Parameters.AddWithValue("@section", model.SectionID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<StudentSection> GetAll()
        {
            var list = new List<StudentSection>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM StudentSection";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudentSection
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            SectionID = Convert.ToInt32(reader["SectionID"])
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
                cmd.CommandText = "DELETE FROM StudentSection WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}