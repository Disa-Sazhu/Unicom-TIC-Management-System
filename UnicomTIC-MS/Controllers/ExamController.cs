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
    public class ExamController
    {
        private ExamService _service = new ExamService();

        public void Add(ExamDto dto)
        {
            try
            {
                _service.AddExam(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add exam failed: " + ex.Message);
            }
        }

        public List<Exam> GetAll()
        {
            return _service.GetAllExams();
        }

        public void Delete(int examId)
        {
            try
            {
                _service.DeleteExam(examId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete exam failed: " + ex.Message);
            }
        }

        public void Update(ExamDto dto)
        {
            try
            {
                _service.UpdateExam(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update exam failed: " + ex.Message);
            }
        }
    }
}
