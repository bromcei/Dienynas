using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int MiniNoGrades { get; set; }
        public string StartFirstSemester { get; set; }
        public string EndFirstSemester { get; set; }
        public string StartSecondSemester { get; set; }
        public string EndSecondSemester { get; set; }


        public Subject(int subjectID, string subjectName, string startFirstSemester, string endFirstSemester, string startSecondSemester, string endSecondSemester )
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            StartFirstSemester = startFirstSemester;
            EndFirstSemester = endFirstSemester;     
            StartSecondSemester = startSecondSemester;
            EndSecondSemester = endSecondSemester

        }
    }
}
