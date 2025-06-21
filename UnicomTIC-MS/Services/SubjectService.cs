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
    public class SubjectService
    {
        private SubjectRepository _repo = new SubjectRepository();

        public void AddSubject(SubjectDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SubjectName))
                throw new Exception("Subject name is required.");

            var subject = new Subject
            {
                SubjectName = dto.SubjectName,
                CourseID = dto.CourseID
            };

            _repo.Add(subject);
        }

        public List<Subject> GetAllSubjects()
        {
            return _repo.GetAll();
        }

        public void DeleteSubject(int subjectId)
        {
            _repo.Delete(subjectId);
        }

        public void UpdateSubject(SubjectDto dto)
        {
            if (dto.SubjectID == null)
                throw new Exception("Subject ID is required for update.");

            var subject = new Subject
            {
                SubjectID = dto.SubjectID.Value,
                SubjectName = dto.SubjectName,
                CourseID = dto.CourseID
            };

            _repo.Update(subject);
        }
    }
}
