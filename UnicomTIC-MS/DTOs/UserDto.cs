using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Enums;

namespace UnicomTIC_MS.DTOs
{
    public class UserDto
    {
        public int? UserID { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}

