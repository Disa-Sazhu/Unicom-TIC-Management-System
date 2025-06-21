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
    public class LecturerService
    {
        private LecturerRepository _repo = new LecturerRepository();

        public void AddLecturer(LecturerDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new Exception("Name is required.");
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email is required.");

            var lecturer = new Lecturer
            {
                Name = dto.Name,
                Email = dto.Email,
                NIC = dto.NIC,
                Gender = dto.Gender
            };

            _repo.Add(lecturer);
        }

        public List<Lecturer> GetAllLecturers()
        {
            return _repo.GetAll();
        }

        public void DeleteLecturer(int lecturerId)
        {
            _repo.Delete(lecturerId);
        }

        public void UpdateLecturer(LecturerDto dto)
        {
            if (dto.LecturerID == null)
                throw new Exception("Lecturer ID is required.");

            var lecturer = new Lecturer
            {
                LecturerID = dto.LecturerID.Value,
                Name = dto.Name,
                Email = dto.Email,
                NIC = dto.NIC,
                Gender = dto.Gender
            };

            _repo.Update(lecturer);
        }
    }
}
