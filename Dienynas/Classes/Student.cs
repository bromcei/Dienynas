using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Grade { get; set; }
        public char GradePrefix { get; set; }
        DateTime DateAdded { get; set; }

        public Student(int studentID, string studentName, int grade, char gradePrefix, DateTime dateAdded)
        {
            StudentID = studentID;
            StudentName = studentName;
            Grade = grade;
            GradePrefix = gradePrefix;
            DateAdded = dateAdded;          
        }
    }
}
