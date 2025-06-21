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
    public class StudentLecturerService
    {
        private StudentLecturerRepository _repo = new StudentLecturerRepository();

        public void AddStudentLecturer(StudentLecturerDto dto)
        {
            if (dto.StudentID <= 0 || dto.LecturerID <= 0)
                throw new Exception("StudentID and LecturerID are required.");

            var model = new StudentLecturer
            {
                StudentID = dto.StudentID,
                LecturerID = dto.LecturerID
            };

            _repo.Add(model);
        }

        public List<StudentLecturer> GetAll()
        {
            return _repo.GetAll();
        }

        public void DeleteStudentLecturer(int id)
        {
            _repo.Delete(id);
        }
    }
}
