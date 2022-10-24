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
        public List<Student> StudentList { get; set; }
        public string StudentsDBPath;

        public StudentsRepository(string env)
        {
            StudentList = new List<Student>();
            if (env == "prod")
            {
                StudentsDBPath = Path.Combine(@"C:\Users\tomas.ceida\Source\Repos\bromcei\Dienynas\Dienynas\", @"Data\Prod\", "Students.txt");
            }
            else if (env == "test")
            {
                StudentsDBPath = Path.Combine(@"C:\Users\tomas.ceida\Source\Repos\bromcei\Dienynas\Dienynas\", @"Data\Test\", "Students_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }
            
            int studentID;
            string studentName;
            int grade;
            char gradePrefix;
            bool isActive;
            bool isGraduated;
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
                    DateTime.TryParse(fileLine[4], out dateAdded) &&
                    bool.TryParse(fileLine[4], out isActive) &&
                    bool.TryParse(fileLine[5], out isGraduated) 
                    )
                {
                    studentName = fileLine[1];
                    StudentList.Add(new Student(studentID, studentName, grade, gradePrefix, dateAdded, isActive, isGraduated));
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

        public bool CheckStudentID(int studentID)
        {
            if (StudentList.Where(s => s.StudentID == studentID).Count() == 1)
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
