using Dienynas.Classes;
using Dienynas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Services
{
    public class SemesterEveluationService
    {
        public StudentsRepository Students { get; set; }
        public TeachersRepository Teachers { get; set; }
        public SubjectRepository Subjects { get; set; }
        public SubjectMarksRepository SubjectMarks { get; set; }
        public SemesterRepository Semesters {get; set;}
        public SemesterEveluationService (StudentsRepository students, TeachersRepository teachers, SubjectRepository subjects, SubjectMarksRepository marks, SemesterRepository semesters)
        {
            Students = students;
            Teachers = teachers;
            Subjects = subjects;    
            SubjectMarks = marks;
            Semesters = semesters;
        }

        public SemesterGrade GetStudentSemesterGrade(int studentID, int subjectID, int semesterID)
        {
            Student student = Students.Retrieve(studentID);
            Subject subject = Subjects.Retrieve(subjectID);
            Semester semester = Semesters.Retrieve(semesterID);
            double semesterGrade;
            List<SubjectMark> subjectMarks = SubjectMarks.GetSubjectMarks(studentID, subjectID).Where(marks => marks.EventDate >= semester.SemesterStart && marks.EventDate <= semester.SemesterEnd).ToList();
            
            double semesterMark;
            semesterMark = subjectMarks.Select(marks => marks.MarkValue).ToList().Average();
            return new SemesterGrade(student, subject, semester, semesterMark);
        }
    }

}
