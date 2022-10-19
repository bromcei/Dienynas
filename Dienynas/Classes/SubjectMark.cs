using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class SubjectMark
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int MarkValue { get; set; }
        public DateTime EventDate { get; set; }

        public SubjectMark(int studentID, int subjectID, int markValue, DateTime eventDate)
        {
            StudentID = studentID;
            SubjectID = subjectID;
            MarkValue = markValue;
            EventDate = eventDate;
        }
    }
}
