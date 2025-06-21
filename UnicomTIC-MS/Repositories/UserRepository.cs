using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Enums;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class UserRepository
    {
        public void AddUser(User user)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, @r)";
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public User GetUser(string username, string password)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Username = @u AND Password = @p";
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string roleValue = reader["Role"].ToString();

                        if (!Enum.TryParse<UserRole>(roleValue, true, out var parsedRole))
                            throw new Exception("Invalid role in database: " + roleValue);

                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = parsedRole
                        };
                    }
                }
            }

            return null;
        }
    }
}