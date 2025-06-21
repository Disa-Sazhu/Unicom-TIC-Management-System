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
    public class SectionController
    {
        private SectionService _service = new SectionService();

        public void Add(SectionDto dto)
        {
            try
            {
                _service.AddSection(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add section failed: " + ex.Message);
            }
        }

        public List<Section> GetAll()
        {
            return _service.GetAllSections();
        }

        public void Delete(int sectionId)
        {
            try
            {
                _service.DeleteSection(sectionId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete section failed: " + ex.Message);
            }
        }

        public void Update(SectionDto dto)
        {
            try
            {
                _service.UpdateSection(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update section failed: " + ex.Message);
            }
        }
    }
}