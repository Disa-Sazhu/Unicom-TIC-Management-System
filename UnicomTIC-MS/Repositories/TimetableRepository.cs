using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Repositories
{
    public class TimetableRepository
    {
        public void Add(Timetable timetable)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Timetables (SubjectID, TimeSlot, RoomID) VALUES (@sub, @slot, @room)";
                cmd.Parameters.AddWithValue("@sub", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@slot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@room", timetable.RoomID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Timetable> GetAll()
        {
            var list = new List<Timetable>();
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Timetables";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Timetable
                        {
                            TimetableID = Convert.ToInt32(reader["TimetableID"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            TimeSlot = reader["TimeSlot"].ToString(),
                            RoomID = Convert.ToInt32(reader["RoomID"])
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
                cmd.CommandText = "DELETE FROM Timetables WHERE TimetableID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Timetable timetable)
        {
            using (var con = DbCon.GetConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Timetables SET SubjectID = @sub, TimeSlot = @slot, RoomID = @room WHERE TimetableID = @id";
                cmd.Parameters.AddWithValue("@sub", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@slot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@room", timetable.RoomID);
                cmd.Parameters.AddWithValue("@id", timetable.TimetableID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}