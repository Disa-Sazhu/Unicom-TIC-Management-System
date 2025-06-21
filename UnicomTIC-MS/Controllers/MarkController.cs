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
    public class MarkController
    {
        private MarkService _service = new MarkService();

        public void Add(MarkDto dto)
        {
            try
            {
                _service.AddMark(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add mark failed: " + ex.Message);
            }
        }

        public List<Mark> GetAll()
        {
            return _service.GetAllMarks();
        }

        public void Delete(int markId)
        {
            try
            {
                _service.DeleteMark(markId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete mark failed: " + ex.Message);
            }
        }

        public void Update(MarkDto dto)
        {
            try
            {
                _service.UpdateMark(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update mark failed: " + ex.Message);
            }
        }
    }
}
