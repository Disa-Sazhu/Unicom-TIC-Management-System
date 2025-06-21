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
    public class StudentCourseController
    {
        private StudentCourseService _service = new StudentCourseService();

        public void Add(StudentCourseDto dto)
        {
            try
            {
                _service.AddStudentCourse(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add failed: " + ex.Message);
            }
        }

        public List<StudentCourse> GetAll()
        {
            return _service.GetAll();
        }

        public void Delete(int id)
        {
            try
            {
                _service.DeleteStudentCourse(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete failed: " + ex.Message);
            }
        }
    }
}