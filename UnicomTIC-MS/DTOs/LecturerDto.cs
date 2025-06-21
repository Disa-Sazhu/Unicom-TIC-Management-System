using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.DTOs
{
    public class LecturerDto
    {
        public int? LecturerID { get; set; }  // Nullable for insert, required for update
        public string Name { get; set; }      // Lecturer full name
        public string Email { get; set; }     // Email address
        public string NIC { get; set; }       // National Identity Card number
        public string Gender { get; set; }    // Male/Female/Other
    }
}

