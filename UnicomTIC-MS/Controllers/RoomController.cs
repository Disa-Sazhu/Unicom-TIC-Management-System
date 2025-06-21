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
    public class RoomController
    {
        private RoomService _service = new RoomService();

        public void Add(RoomDto dto)
        {
            try
            {
                _service.AddRoom(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add room failed: " + ex.Message);
            }
        }

        public List<Room> GetAll()
        {
            return _service.GetAllRooms();
        }

        public void Delete(int roomId)
        {
            try
            {
                _service.DeleteRoom(roomId);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete room failed: " + ex.Message);
            }
        }

        public void Update(RoomDto dto)
        {
            try
            {
                _service.UpdateRoom(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Update room failed: " + ex.Message);
            }
        }
    }
}
