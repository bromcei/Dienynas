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

            if (grade > 0 && grade <= 12){
                StudentID = studentID;
                StudentName = studentName;
                Grade = grade;
                GradePrefix = gradePrefix;
                DateAdded = dateAdded;
                IsActive = isActive;
                IsGraduated = isGraduated;
            }
            else
            {
                throw new ArgumentException("Mokinio klase negali buti maziau uz 0 arba daugiau nei 12!");
            }

        }



        public bool MoveToNextGrade()
        {
            if (Grade < 12 && Grade > 0)
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
