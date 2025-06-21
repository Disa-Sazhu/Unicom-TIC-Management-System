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
    public class StudentService
    {
        private StudentRepository _repo = new StudentRepository();

        public void AddStudent(StudentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new Exception("First name is required.");

            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Email = dto.Email,
                NIC = dto.NIC,
                Gender = dto.Gender,
                Course = dto.Course,
                Role = dto.Role
            };

            _repo.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _repo.GetAll();
        }

        public void DeleteStudent(int id)
        {
            _repo.Delete(id);
        }

        public void UpdateStudent(StudentDto dto)
        {
            if (dto.StudentID == null)
                throw new Exception("Student ID is required for update.");

            var student = new Student
            {
                StudentID = dto.StudentID.Value,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Email = dto.Email,
                NIC = dto.NIC,
                Gender = dto.Gender,
                Course = dto.Course,
                Role = dto.Role
            };

            _repo.Update(student);
        }
    }
}