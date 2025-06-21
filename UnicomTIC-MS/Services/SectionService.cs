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
    public class SectionService
    {
        private SectionRepository _repo = new SectionRepository();

        public void AddSection(SectionDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SectionName))
                throw new Exception("Section name is required.");

            var section = new Section
            {
                SectionName = dto.SectionName
            };

            _repo.Add(section);
        }

        public List<Section> GetAllSections()
        {
            return _repo.GetAll();
        }

        public void DeleteSection(int sectionId)
        {
            _repo.Delete(sectionId);
        }

        public void UpdateSection(SectionDto dto)
        {
            if (dto.SectionID == null)
                throw new Exception("Section ID is required.");

            var section = new Section
            {
                SectionID = dto.SectionID.Value,
                SectionName = dto.SectionName
            };

            _repo.Update(section);
        }
    }
}
