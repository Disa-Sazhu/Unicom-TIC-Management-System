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
    public class StudentCourseService
    {
        private StudentCourseRepository _repo = new StudentCourseRepository();

        public void AddStudentCourse(StudentCourseDto dto)
        {
            if (dto.StudentID <= 0 || dto.CourseID <= 0)
                throw new Exception("Student and Course IDs are required.");

            var model = new StudentCourse
            {
                StudentID = dto.StudentID,
                CourseID = dto.CourseID
            };

            _repo.Add(model);
        }

        public List<StudentCourse> GetAll()
        {
            return _repo.GetAll();
        }

        public void DeleteStudentCourse(int id)
        {
            _repo.Delete(id);
        }
    }
}
