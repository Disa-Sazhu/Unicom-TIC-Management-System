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
    public class StudentSectionController
    {
        private StudentSectionService _service = new StudentSectionService();

        public void Add(StudentSectionDto dto)
        {
            try
            {
                _service.AddStudentSection(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add StudentSection: " + ex.Message);
            }
        }

        public List<StudentSection> GetAll()
        {
            return _service.GetAll();
        }

        public void Delete(int id)
        {
            try
            {
                _service.DeleteStudentSection(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete StudentSection: " + ex.Message);
            }
        }
    }
}
