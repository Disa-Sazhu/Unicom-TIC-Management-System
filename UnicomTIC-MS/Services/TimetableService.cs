using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.DTOs;
using UnicomTIC_MS.Models;
using UnicomTIC_MS.Repositories;

namespace UnicomTIC_MS.Services
{
    public class TimetableService
    {
        private TimetableRepository _repo = new TimetableRepository();

        public void AddTimetable(TimetableDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TimeSlot))
                throw new Exception("Time slot is required.");

            var timetable = new Timetable
            {
                SubjectID = dto.SubjectID,
                TimeSlot = dto.TimeSlot,
                RoomID = dto.RoomID
            };

            _repo.Add(timetable);
        }

        public List<Timetable> GetAllTimetables()
        {
            return _repo.GetAll();
        }

        public void DeleteTimetable(int id)
        {
            _repo.Delete(id);
        }

        public void UpdateTimetable(TimetableDto dto)
        {
            if (dto.TimetableID == null)
                throw new Exception("Timetable ID is required for update.");

            var timetable = new Timetable
            {
                TimetableID = dto.TimetableID.Value,
                SubjectID = dto.SubjectID,
                TimeSlot = dto.TimeSlot,
                RoomID = dto.RoomID
            };

            _repo.Update(timetable);
        }
    }
}
