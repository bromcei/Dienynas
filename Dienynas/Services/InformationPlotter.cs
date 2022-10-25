using Dienynas.Classes;
using Dienynas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Dienynas.Services
{
    public class InformationPlotter
    {
        public StudentsRepository Students { get; set; }
        public TeachersRepository Teachers { get; set; }
        public SubjectRepository Subjects { get; set; }
        public SubjectMarksRepository SubjectMarks { get; set; }
        public SemesterRepository Semesters { get; set; }

        public InformationPlotter(StudentsRepository students, TeachersRepository teachers, SubjectRepository subjects, SubjectMarksRepository subjectMarks, SemesterRepository semesters)
        {
            Students = students;
            Teachers = teachers;
            Subjects = subjects;
            SubjectMarks = subjectMarks;
            Semesters = semesters;
        }

        public ConsoleTable PlotClassStudents(string classVal)
        {
            
            ConsoleTable resString = new ConsoleTable("StudentID", "StudentName", "Grade", "GradePrefix");
            int grade;
            List<Student> studentsList;
            if (classVal == "all")
            {
                studentsList = Students.Retrieve();
            }
            else if(int.TryParse(classVal, out grade))
            {
                studentsList = Students.RetrieveByGrade(grade);
            }
            else
            {
                studentsList = new List<Student>();
            }
            if (studentsList.Count > 0)
            {
                foreach (Student student in studentsList)
                {
                    resString.AddRow(student.StudentID, student.StudentName, student.Grade, student.GradePrefix);
                }
            }

            return resString;

        }
        public ConsoleTable PlotClassSubjects(string classVal)
        {

            ConsoleTable resString = new ConsoleTable("SubjectID", "SubjectName", "Grade", "MinNoGrades");
            int grade;
            List<Subject> subjectsList;
            if (classVal == "all")
            {
                subjectsList = Subjects.Retrieve();
            }
            else if (int.TryParse(classVal, out grade))
            {
                subjectsList = Subjects.RetrieveByGrade(grade);
            }
            else
            {
                subjectsList = new List<Subject>();
            }
            if (subjectsList.Count > 0)
            {
                foreach (Subject subject in subjectsList)
                {
                    resString.AddRow(subject.SubjectID, subject.SubjectName, subject.Grade, subject.MinNoGrades);
                }
            }

            return resString;

        }
    }
}
