using Dienynas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Repositories
{
    public class StudentsRepository
    {
        List<Student> StudentList { get; set; }
        string StudentsDBPath;

        public StudentsRepository()
        {
            StudentList = new List<Student>();
            StudentsDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "Students.txt");
            int studentID;
            string studentName;
            int grade;
            char gradePrefix;
            string[] fileLine;
            char[] possibleGradePrefixes = { 'A', 'B', 'C' };
            DateTime dateAdded;

            foreach (string line in File.ReadAllLines(StudentsDBPath))
            {
                fileLine = line.Split(";");
                gradePrefix = '-';
                if (
                    int.TryParse(fileLine[0], out studentID) &&
                    fileLine[1].Length >0 &&
                    int.TryParse(fileLine[2], out grade) &&
                    char.TryParse(fileLine[3], out gradePrefix) &&
                    possibleGradePrefixes.Contains(gradePrefix) &&
                    DateTime.TryParse(fileLine[4], out dateAdded)
                    )
                {
                    studentName = fileLine[1];
                    StudentList.Add(new Student(studentID, studentName, grade, gradePrefix, dateAdded));
                }
                //else
                //{
                    //ErrorBlinkStyle file pildymas
                //}
            }
            
        }
        public List<Student> Retrieve()
        {
            return StudentList;
        }
        public Student Retrieve(int studentID)
        {
            return StudentList.Where(s => s.StudentID == studentID).FirstOrDefault();
        }
    }

}
