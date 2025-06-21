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
    public class StudentExamService
    {
        private StudentExamRepository _repo = new StudentExamRepository();

        public void Add(StudentExamDto dto)
        {
            var model = new StudentExam
            {
                StudentID = dto.StudentID,
                ExamID = dto.ExamID
            };
            _repo.Add(model);
        }

        public List<StudentExam> GetAll() => _repo.GetAll();
        public void Delete(int id) => _repo.Delete(id);
    }
}
