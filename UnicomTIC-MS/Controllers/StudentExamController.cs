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
    public class StudentExamController
    {
        private StudentExamService _service = new StudentExamService();

        public void Add(StudentExamDto dto) => _service.Add(dto);
        public List<StudentExam> GetAll() => _service.GetAll();
        public void Delete(int id) => _service.Delete(id);
    }
}
