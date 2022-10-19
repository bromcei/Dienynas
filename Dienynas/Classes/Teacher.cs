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
        public int SubjectID { get; set; }
        public int PerceptorGrade { get; set; }
        public char PerceptorGradePrefix { get; set; }
        DateTime DateAdded { get; set; }

        public Teacher(int techerID, string teacherName, int subjectID, int perceptorGrade, char perceptorGradePrefix, DateTime dateAdded)
        {
            TeacherID = techerID;
            TeacherName = teacherName;
            SubjectID = subjectID;
            PerceptorGrade = perceptorGrade;
            PerceptorGradePrefix = perceptorGradePrefix;    
            DateAdded = dateAdded;
        }

    }
}
