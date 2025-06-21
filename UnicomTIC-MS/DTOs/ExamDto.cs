using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.DTOs
{
    public class ExamDto
    {
        public int? ExamID { get; set; }           // Nullable for insert
        public string ExamName { get; set; }       // Name of the exam
        public int SubjectID { get; set; }         // Linked subject
    }
}

