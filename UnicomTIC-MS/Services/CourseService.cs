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
    public class CourseService
    {
        private CourseRepository _repo = new CourseRepository();

        public void AddCourse(CourseDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CourseName))
                throw new Exception("Course name is required.");

            var course = new Course
            {
                CourseName = dto.CourseName
            };

            _repo.Add(course);
        }

        public List<Course> GetAllCourses()
        {
            return _repo.GetAll();
        }

        public void DeleteCourse(int courseId)
        {
            _repo.Delete(courseId);
        }

        public void UpdateCourse(CourseDto dto)
        {
            if (dto.CourseID == null)
                throw new Exception("Course ID is required.");
            if (string.IsNullOrWhiteSpace(dto.CourseName))
                throw new Exception("Course name is required.");

            var course = new Course
            {
                CourseID = dto.CourseID.Value,
                CourseName = dto.CourseName
            };

            _repo.Update(course);
        }
    }
}
