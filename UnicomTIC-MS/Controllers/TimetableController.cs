using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.DTOs;
using UnicomTIC_MS.Models;
using UnicomTIC_MS.Services;

namespace UnicomTIC_MS.Controllers
{
    public class TimetableController
    {
        private TimetableService _service = new TimetableService();

        public void Add(TimetableDto dto)
        {
            try
            {
                _service.AddTimetable(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add timetable failed: " + ex.Message);
            }
        }

        public List<Timetable> GetAll()
        {
            return _service.GetAllTimetables();
        }

        public void Delete(int id)
        {
            try
            {
                _service.DeleteTimetable(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete timetable failed: " + ex.Message);
            }
        }

        public void Update(TimetableDto dto)
        {
            try
            {
                _service.UpdateTimetable(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update timetable failed: " + ex.Message);
            }
        }
    }
}