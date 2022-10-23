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
        public string SemesterName { get; set; }

        public SubjectMark(int markID, int studentID, int teacherID, int subjectID, double markValue, DateTime eventDate)
        {
            MarkID = markID;
            StudentID = studentID;
            TeacherID = teacherID;
            SubjectID = subjectID;
            MarkValue = markValue;
            EventDate = eventDate;
            int monthNo = EventDate.Month;
            if (monthNo >= 9 && monthNo <= 12)
            {
                SemesterName = EventDate.ToString("yyyy") + "-" + (EventDate.Year + 1).ToString() + " 1st Semester";
            }
            else
            {
                SemesterName = (EventDate.Year - 1).ToString() + EventDate.ToString("yyyy") + " 2nd Semester";
            }
            
             
        }
        public bool ChangeMark(int newMark)
        {
            if (newMark > 0 && newMark <= 10){
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
