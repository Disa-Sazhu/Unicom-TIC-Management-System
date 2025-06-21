using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.DTOs
{
    public class StudentDto
    {
        public int? StudentID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string Gender { get; set; }
        public string Course { get; set; }
        public string Role { get; set; }
    }
}
