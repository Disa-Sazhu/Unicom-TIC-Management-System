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
    public class StudentController
    {
        private StudentService _service = new StudentService();

        public void Add(StudentDto dto)
        {
            try
            {
                _service.AddStudent(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add student failed: " + ex.Message);
            }
        }

        public List<Student> GetAll()
        {
            return _service.GetAllStudents();
        }

        public void Delete(int studentId)
        {
            try
            {
                _service.DeleteStudent(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete student failed: " + ex.Message);
            }
        }

        public void Update(StudentDto dto)
        {
            try
            {
                _service.UpdateStudent(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update student failed: " + ex.Message);
            }
        }
    }
}