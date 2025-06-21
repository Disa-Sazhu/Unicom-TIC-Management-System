using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.DTOs
{
    public class TimetableDto
    {
        public int? TimetableID { get; set; }
        public int SubjectID { get; set; }
        public string TimeSlot { get; set; }
        public int RoomID { get; set; }
    }
}

