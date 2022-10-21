using Dienynas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Repositories
{
    public class SubjectMarksRepository
    {
        public List<SubjectMark> SubjectMarksList { get; set; }
        string SubjectMarksDBPath;

        public SubjectMarksRepository()
        {
            SubjectMarksList = new List<SubjecMark>();
            StudentsDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Prod", "SubjectMarks.txt");
            int markID;
            int studentID;
            int teacherID;
            int subjectID;
            double markValue;
            DateTime dateAdded;

            foreach (string line in File.ReadAllLines(StudentsDBPath))
            {
                fileLine = line.Split(";");
                gradePrefix = '-';
                if (
                    int.TryParse(fileLine[0], out markID) &&
                    int.TryParse(fileLine[1], out studentID) &&
                    int.TryParse(fileLine[2], out teacherID) &&
                    int.TryParse(fileLine[3], out subjectID) &&
                    double.TryParse(fileLine[4], out markValue) &&
                    DateTime.TryParse(fileLine[5], out dateAdded)
                    )
                {
                    SubjectMarksList.Add(new SubjectMark(markID, studentID, teacherID, subjectID, markValue, dateAdded));
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
