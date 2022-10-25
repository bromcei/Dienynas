using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class Semester
    {
        public int SemesterID { get; set; }
        public int SemesterNo { get; set; }
        public String SemesterName { get; set; }
        public DateTime SemesterStart { get; set; }
        public DateTime SemesterEnd { get; set; }
        public string SchoolYear { get; set; }
        public bool CurrentYear { get; set; }

        public Semester(int semesterID, int semesterNo, String semesterName, DateTime semesterStart, DateTime semesterEnd, string schoolYear, bool currentYear)
        {
            SemesterID = semesterID;
            SemesterNo = semesterNo;
            SemesterName = semesterName;
            SemesterStart = semesterStart;
            SemesterEnd = semesterEnd;
            SchoolYear = schoolYear;
            CurrentYear = currentYear;
        }
    }

}
