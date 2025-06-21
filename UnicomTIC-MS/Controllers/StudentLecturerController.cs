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
    public class StudentLecturerController
    {
        private StudentLecturerService _service = new StudentLecturerService();

        public void Add(StudentLecturerDto dto)
        {
            try
            {
                _service.AddStudentLecturer(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add failed: " + ex.Message);
            }
        }

        public List<StudentLecturer> GetAll()
        {
            return _service.GetAll();
        }

        public void Delete(int id)
        {
            try
            {
                _service.DeleteStudentLecturer(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete failed: " + ex.Message);
            }
        }
    }
}
