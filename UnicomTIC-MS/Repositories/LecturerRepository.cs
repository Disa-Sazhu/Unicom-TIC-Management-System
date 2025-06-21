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
    public class LecturerRepository
    {
        public void Add(Lecturer lecturer)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Lecturers (Name, Email, NIC, Gender) VALUES (@Name, @Email, @NIC, @Gender)";
                cmd.Parameters.AddWithValue("@Name", lecturer.Name);
                cmd.Parameters.AddWithValue("@Email", lecturer.Email);
                cmd.Parameters.AddWithValue("@NIC", lecturer.NIC);
                cmd.Parameters.AddWithValue("@Gender", lecturer.Gender);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Lecturer> GetAll()
        {
            var list = new List<Lecturer>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Lecturers";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Lecturer
                        {
                            LecturerID = Convert.ToInt32(reader["LecturerID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            NIC = reader["NIC"].ToString(),
                            Gender = reader["Gender"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Delete(int lecturerId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Lecturers WHERE LecturerID = @id";
                cmd.Parameters.AddWithValue("@id", lecturerId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Lecturer lecturer)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Lecturers SET Name = @Name, Email = @Email, NIC = @NIC, Gender = @Gender WHERE LecturerID = @id";
                cmd.Parameters.AddWithValue("@Name", lecturer.Name);
                cmd.Parameters.AddWithValue("@Email", lecturer.Email);
                cmd.Parameters.AddWithValue("@NIC", lecturer.NIC);
                cmd.Parameters.AddWithValue("@Gender", lecturer.Gender);
                cmd.Parameters.AddWithValue("@id", lecturer.LecturerID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}