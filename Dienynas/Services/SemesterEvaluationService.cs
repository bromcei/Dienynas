using Dienynas.Classes;
using Dienynas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dienynas.Services
{
    public class SemesterEvaluationService
    {
        public StudentsRepository Students { get; set; }
        public TeachersRepository Teachers { get; set; }
        public SubjectRepository Subjects { get; set; }
        public SubjectMarksRepository SubjectMarks { get; set; }
        public SemesterRepository Semesters {get; set;}
        public SemesterEvaluationService (StudentsRepository students, TeachersRepository teachers, SubjectRepository subjects, SubjectMarksRepository marks, SemesterRepository semesters)
        {
            Students = students;
            Teachers = teachers;
            Subjects = subjects;    
            SubjectMarks = marks;
            Semesters = semesters;
        }

        public SemesterGrade GetStudentSemesterGrade(int studentID, int subjectID, int semesterNo)
        {
            Student student = Students.Retrieve(studentID);
            Subject subject = Subjects.Retrieve(subjectID);
            Semester semester = Semesters.RetrieveCurrentByNo(semesterNo);
            double semesterGrade;
            List<SubjectMark> subjectMarks = SubjectMarks.GetSubjectMarks(studentID, subjectID).Where(marks => marks.EventDate >= semester.SemesterStart && marks.EventDate <= semester.SemesterEnd).ToList();
            
            double semesterMark;
            if (subjectMarks.Count > subject.MinNoGrades)
            {
                semesterMark = subjectMarks.Select(marks => marks.MarkValue).ToList().Average();
                semesterMark = Math.Round(semesterMark, 0);
            }
            else
            {
                semesterMark = 0;
            }
            return new SemesterGrade(student, subject, semester, semesterMark);
        }
        public List<SemesterGrade> GetAllStudentSemesterGrades(int studentID)
        {
            Student student = Students.Retrieve(studentID);
            List<Subject> subjectsList = Subjects.RetrieveByGrade(student.Grade);
            List<SemesterGrade> semesterGradesList = new List<SemesterGrade>();
            foreach (Semester semester in Semesters.Retrieve().Where(sem => sem.CurrentYear == true).ToList())
            {
                foreach (Subject subject in subjectsList)
                {
                    semesterGradesList.Add(GetStudentSemesterGrade(studentID, subject.SubjectID, semester.SemesterNo));
                }
            }

            return semesterGradesList;

        }

        public List<List<SemesterGrade>> AllStudentsSemesterGrades()
        {
            List <List<SemesterGrade>> allSemesterGradesList = new List<List<SemesterGrade>>();
            foreach(Student student in Students.StudentList)
            {
                allSemesterGradesList.Add(GetAllStudentSemesterGrades(student.StudentID));
            }
            return allSemesterGradesList;
        }
    }

}
