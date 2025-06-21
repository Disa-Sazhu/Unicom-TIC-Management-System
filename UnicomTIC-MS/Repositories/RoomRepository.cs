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
    public class RoomRepository
    {
        public void Add(Room room)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Rooms (RoomName, RoomType) VALUES (@RoomName, @RoomType)";
                cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Room> GetAll()
        {
            var rooms = new List<Room>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Rooms";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString()
                        });
                    }
                }
            }
            return rooms;
        }

        public void Delete(int roomId)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Rooms WHERE RoomID = @id";
                cmd.Parameters.AddWithValue("@id", roomId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Room room)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Rooms SET RoomName = @name, RoomType = @type WHERE RoomID = @id";
                cmd.Parameters.AddWithValue("@name", room.RoomName);
                cmd.Parameters.AddWithValue("@type", room.RoomType);
                cmd.Parameters.AddWithValue("@id", room.RoomID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}