using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public List<int> SubjectIDList { get; set; }
        public int PerceptorGrade { get; set; }
        public char PerceptorGradePrefix { get; set; }
        DateTime DateAdded { get; set; }

        public Teacher(int techerID, string teacherName, List<int> subjectIDList, int perceptorGrade, char perceptorGradePrefix, DateTime dateAdded)
        {
            TeacherID = techerID;
            TeacherName = teacherName;
            SubjectIDList = subjectIDList;
            PerceptorGrade = perceptorGrade;
            PerceptorGradePrefix = perceptorGradePrefix;    
            DateAdded = dateAdded;
        }

        public bool CanTeacherTeachSubject(int subjectID)
        {
            if (SubjectIDList.Contains(subjectID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
