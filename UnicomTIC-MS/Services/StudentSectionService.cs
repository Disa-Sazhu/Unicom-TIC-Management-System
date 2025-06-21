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
    public class StudentSectionService
    {
        private StudentSectionRepository _repo = new StudentSectionRepository();

        public void AddStudentSection(StudentSectionDto dto)
        {
            if (dto.StudentID <= 0 || dto.SectionID <= 0)
                throw new Exception("StudentID and SectionID must be valid.");

            var model = new StudentSection
            {
                StudentID = dto.StudentID,
                SectionID = dto.SectionID
            };

            _repo.Add(model);
        }

        public List<StudentSection> GetAll()
        {
            return _repo.GetAll();
        }

        public void DeleteStudentSection(int id)
        {
            _repo.Delete(id);
        }
    }
}
