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
    public class CourseController
    {
        private CourseService _service = new CourseService();

        public void Add(CourseDto dto)
        {
            try
            {
                _service.AddCourse(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add course failed: " + ex.Message);
            }
        }

        public List<Course> GetAll()
        {
            return _service.GetAllCourses();
        }

        public void Delete(int courseId)
        {
            try
            {
                _service.DeleteCourse(courseId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete course failed: " + ex.Message);
            }
        }

        public void Update(CourseDto dto)
        {
            try
            {
                _service.UpdateCourse(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update course failed: " + ex.Message);
            }
        }
    }
}