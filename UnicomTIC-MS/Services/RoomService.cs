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
    public class RoomService
    {
        private RoomRepository _repo = new RoomRepository();

        public void AddRoom(RoomDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.RoomName))
                throw new Exception("Room name is required.");
            if (string.IsNullOrWhiteSpace(dto.RoomType))
                throw new Exception("Room type is required.");

            var room = new Room
            {
                RoomName = dto.RoomName,
                RoomType = dto.RoomType
            };

            _repo.Add(room);
        }

        public List<Room> GetAllRooms()
        {
            return _repo.GetAll();
        }

        public void DeleteRoom(int roomId)
        {
            _repo.Delete(roomId);
        }

        public void UpdateRoom(RoomDto dto)
        {
            if (dto.RoomID == null)
                throw new Exception("Room ID is required for update.");

            var room = new Room
            {
                RoomID = dto.RoomID.Value,
                RoomName = dto.RoomName,
                RoomType = dto.RoomType
            };

            _repo.Update(room);
        }
    }
}

