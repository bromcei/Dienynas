using Dienynas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Services
{
    public class StudentsMarkingService
    {
        public StudentsRepository Students { get; set; }
        public TeachersRepository Teachers { get; set; }
        public SubjectRepository Subjects { get; set; }
        public SubjectMarksRepository SubjectMarks { get; set; }

        public StudentsMarkingService(StudentsRepository students, TeachersRepository teachers, SubjectRepository subjects, SubjectMarksRepository subjectMarks)
        {
            Students = students;
            Teachers = teachers;
            Subjects = subjects;
            SubjectMarks = subjectMarks;
        }

        public bool AddNewMark(int studentID, int teacherID, int subjectID, double subjectMark, DateTime addedOn)
        {
            string addedOnStr = addedOn.ToString("yyyy-MM-dd");
            if (
                Students.CheckStudentID(studentID) &&
                Teachers.CheckTeacherID(teacherID) &&
                Subjects.CheckSubjectID(subjectID) 
                )
            {
                if (Teachers.Retrieve(teacherID).CanTeacherTeachSubject(subjectID))
                {
                    int newMarkID = SubjectMarks.GetMaxMarkID() + 1;
                    string newMarkInsertLine = $"{newMarkID};{studentID};{teacherID};{subjectMark};{addedOnStr};";
                    File.AppendAllText(SubjectMarks.SubjectMarksDBPath, DateTime.Now.ToString() + Environment.NewLine);
                    return true;
                }

            else
            {
                return false;
            }

            }
            else
            {
                return false;
            }

        }

    }
}
