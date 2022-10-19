using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    internal class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public List<int> GradesIDsTeached { get; set; }

        public Subject(int subjectID, string subjectName, List<int> gradesIDsTeached)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            GradesIDsTeached = gradesIDsTeached;
        }
    }
}
