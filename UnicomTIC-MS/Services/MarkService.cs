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
    public class MarkService
    {
        private MarkRepository _repo = new MarkRepository();

        public void AddMark(MarkDto dto)
        {
            if (dto.Score < 0 || dto.Score > 100)
                throw new Exception("Score must be between 0 and 100.");

            var mark = new Mark
            {
                StudentID = dto.StudentID,
                ExamID = dto.ExamID,
                Score = dto.Score
            };

            _repo.Add(mark);
        }

        public List<Mark> GetAllMarks()
        {
            return _repo.GetAll();
        }

        public void DeleteMark(int markId)
        {
            _repo.Delete(markId);
        }

        public void UpdateMark(MarkDto dto)
        {
            if (dto.MarkID == null)
                throw new Exception("Mark ID is required for update.");

            if (dto.Score < 0 || dto.Score > 100)
                throw new Exception("Score must be between 0 and 100.");

            var mark = new Mark
            {
                MarkID = dto.MarkID.Value,
                StudentID = dto.StudentID,
                ExamID = dto.ExamID,
                Score = dto.Score
            };

            _repo.Update(mark);
        }
    }
}
