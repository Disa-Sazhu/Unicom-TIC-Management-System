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
    public class SubjectController
    {
        private SubjectService _service = new SubjectService();

        public void Add(SubjectDto dto)
        {
            try
            {
                _service.AddSubject(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add subject failed: " + ex.Message);
            }
        }

        public List<Subject> GetAll()
        {
            return _service.GetAllSubjects();
        }

        public void Delete(int subjectId)
        {
            try
            {
                _service.DeleteSubject(subjectId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete subject failed: " + ex.Message);
            }
        }

        public void Update(SubjectDto dto)
        {
            try
            {
                _service.UpdateSubject(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update subject failed: " + ex.Message);
            }
        }
    }
}
