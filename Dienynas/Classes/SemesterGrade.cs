using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Classes
{
    public class SemesterGrade
    {
        public Student Student { get; set; }    
        public Subject Subject { get; set; }    
        public Semester Semester { get; set; }
        public double SemesterGradeValue { get; set; }

        public SemesterGrade(Student student, Subject subject, Semester semester, double semesterGrade)
        {
            Student = student;
            Subject = subject;
            Semester = semester;
            SemesterGradeValue = semesterGrade;
        }
    }
}
