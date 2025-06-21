using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class SectionRepository
    {
        public void Add(Section section)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Sections (SectionName) VALUES (@name)";
                cmd.Parameters.AddWithValue("@name", section.SectionName);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Section> GetAll()
        {
            var list = new List<Section>();

            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Sections";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Section
                        {
                            SectionID = Convert.ToInt32(reader["SectionID"]),
                            SectionName = reader["SectionName"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public void Delete(int sectionId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Sections WHERE SectionID = @id";
                cmd.Parameters.AddWithValue("@id", sectionId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Section section)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Sections SET SectionName = @name WHERE SectionID = @id";
                cmd.Parameters.AddWithValue("@name", section.SectionName);
                cmd.Parameters.AddWithValue("@id", section.SectionID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}