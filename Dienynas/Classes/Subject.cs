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
        public int Grade { get; set; }  
        public int MinNoGrades { get; set; }



        public Subject(int subjectID, string subjectName, int grade, int minNoGrades)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Grade = grade;
            MinNoGrades = minNoGrades;
        }
    }
}
