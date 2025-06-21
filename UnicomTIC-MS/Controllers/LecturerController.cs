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
    public class LecturerController
    {
        private LecturerService _service = new LecturerService();

        public void Add(LecturerDto dto)
        {
            try
            {
                _service.AddLecturer(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add lecturer failed: " + ex.Message);
            }
        }

        public List<Lecturer> GetAll()
        {
            return _service.GetAllLecturers();
        }

        public void Delete(int lecturerId)
        {
            try
            {
                _service.DeleteLecturer(lecturerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete lecturer failed: " + ex.Message);
            }
        }

        public void Update(LecturerDto dto)
        {
            try
            {
                _service.UpdateLecturer(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update lecturer failed: " + ex.Message);
            }
        }
    }
}
