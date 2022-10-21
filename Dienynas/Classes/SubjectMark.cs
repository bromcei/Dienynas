using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class SubjectMark
    {
        public int MarkID { get; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public double MarkValue { get; set; }
        public DateTime EventDate { get; set; }

        public SubjectMark(int markID, int studentID, int teacherID, int subjectID, double markValue, DateTime eventDate)
        {
            MarkID = markID;
            StudentID = studentID;
            TeacherID = teacherID;
            SubjectID = subjectID;
            MarkValue = markValue;
            EventDate = eventDate;
             
        }
        public bool ChangeMark(int newMark)
        {
            if (newMark > 0 and newMark <= 10){
                MarkValue = newMark;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
