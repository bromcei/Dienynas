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
        public String SemesterName { get; set; }
        public DateTime SemesterStart { get; set; }
        public DateTime SemesterEnd { get; set; }

        public Semester(int semesterID, String semesterName, DateTime semesterStart, DateTime semesterEnd)
        {
            SemesterID = semesterID;
            SemesterName = semesterName;
            SemesterStart = semesterStart;
            SemesterEnd = semesterEnd;
        }
    }

}
