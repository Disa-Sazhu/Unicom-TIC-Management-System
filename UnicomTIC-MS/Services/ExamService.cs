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
    public class ExamService
    {
        private ExamRepository _repo = new ExamRepository();

        public void AddExam(ExamDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ExamName))
                throw new Exception("Exam name is required.");

            var exam = new Exam
            {
                ExamName = dto.ExamName,
                SubjectID = dto.SubjectID
            };

            _repo.Add(exam);
        }

        public List<Exam> GetAllExams()
        {
            return _repo.GetAll();
        }

        public void DeleteExam(int examId)
        {
            _repo.Delete(examId);
        }

        public void UpdateExam(ExamDto dto)
        {
            if (dto.ExamID == null)
                throw new Exception("Exam ID is required for update.");

            var exam = new Exam
            {
                ExamID = dto.ExamID.Value,
                ExamName = dto.ExamName,
                SubjectID = dto.SubjectID
            };

            _repo.Update(exam);
        }
    }
}

