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
        public DateTime DateAdded { get; set; }
        public bool IsActive { get; set; } 
        public bool IsGraduated { get; set; }

        public Student(int studentID, string studentName, int grade, char gradePrefix, DateTime dateAdded, bool isActive, bool isGraduated)
        {
            StudentID = studentID;
            StudentName = studentName;
            if (grade > 0 and grade <= 12){
                Grade = grade;
            }
            else
            {
                return false;
                break;
            }
            GradePrefix = gradePrefix;
            DateAdded = dateAdded;          
            IsActive = isActive;
            IsGraduated = isGraduated;
        }



        public bool MoveToNextGrade()
        {
            if (Grade < 12 and Grade > 0)
            {
                Grade += 1;
                return true;
            }
            else if (Grade == 12)
            {
                IsGraduated = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangeStudentClass(char newClassPrefix)
        {
            GradePrefix = newClassPrefix;
            return true;
        }
    }
}
