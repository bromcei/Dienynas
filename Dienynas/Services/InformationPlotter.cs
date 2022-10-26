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
        public SemesterEvaluationService SemesterEvalService { get; set; }

        public InformationPlotter(
            StudentsRepository students,
            TeachersRepository teachers,
            SubjectRepository subjects,
            SubjectMarksRepository subjectMarks,
            SemesterRepository semesters,
            SemesterEvaluationService semesterEveluationService)
        {
            Students = students;
            Teachers = teachers;
            Subjects = subjects;
            SubjectMarks = subjectMarks;
            Semesters = semesters;
            SemesterEvalService = semesterEveluationService;
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
            else if (int.TryParse(classVal, out grade))
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

        public ConsoleTable PlotStudentGradesSingleSubject(int studentIDInput, string subjectIDInput)
        {

            ConsoleTable resString = new ConsoleTable("Date", "StudentName", "TeacherName", "SubjectName", "MarkValue");
            int subjectID;
            List<SubjectMark> markList;

            if (
                int.TryParse(subjectIDInput, out subjectID)
                )
            {
                markList = SubjectMarks.GetSubjectMarks(studentIDInput, subjectID);
            }
            else
            {
                markList = new List<SubjectMark>();
            }
            if (markList.Count > 0)
            {
                foreach (SubjectMark mark in markList)
                {
                    resString.AddRow(
                        mark.EventDate.ToString("yyyy-MM-dd"),
                        Students.Retrieve(mark.StudentID).StudentName,
                        Teachers.Retrieve(mark.TeacherID).TeacherName,
                        Subjects.Retrieve(mark.SubjectID).SubjectName,
                        mark.MarkValue);
                }
            }

            return resString;
        }

        public ConsoleTable PlotStudentGrades(int studentIDInput)
        {

            ConsoleTable resString = new ConsoleTable("Date", "StudentName", "TeacherName", "SubjectName", "MarkValue");
            List<SubjectMark> markList;


            markList = SubjectMarks.GetStudentMarks(studentIDInput);
            markList.OrderBy(s => s.EventDate);
            if (markList.Count > 0)
            {
                foreach (SubjectMark mark in markList)
                {
                    resString.AddRow(
                        mark.EventDate.ToString("yyyy-MM-dd"),
                        Students.Retrieve(mark.StudentID).StudentName,
                        Teachers.Retrieve(mark.TeacherID).TeacherName,
                        Subjects.Retrieve(mark.SubjectID).SubjectName,
                        mark.MarkValue);
                }
            }
            return resString;
        }
        public ConsoleTable StudentSemesterGrades(int studentID)
        {
            ConsoleTable resString = new ConsoleTable(
                "StudentID",
                "Grade",
                "StudentName",
                "SubjectName",
                "1st Semester",
                "2nd semester",
                "3rd Semester",
                "Final Grade");
            List<SemesterGrade> semesterGrades = SemesterEvalService.GetAllStudentSemesterGrades(studentID);
            Student student = Students.Retrieve(studentID);
            List<Subject> subjects = Subjects.RetrieveByGrade(student.Grade);

            List<SemesterGrade> subjectGrades;
            SemesterGrade firstGrade;
            SemesterGrade secondGrade;
            SemesterGrade thirdGrade;
            double finalGrade;

            foreach (Subject subject in subjects)
            {
                subjectGrades = semesterGrades.Where(grades => grades.Subject.SubjectID == subject.SubjectID).ToList();
                firstGrade = subjectGrades.First(grades => grades.Semester.SemesterNo == 1);
                secondGrade = subjectGrades.First(grades => grades.Semester.SemesterNo == 2);
                thirdGrade = subjectGrades.First(grades => grades.Semester.SemesterNo == 3);
                finalGrade = Math.Round((firstGrade.SemesterGradeValue + secondGrade.SemesterGradeValue + thirdGrade.SemesterGradeValue) / 3.0, 0);
                resString.AddRow(
                    student.StudentID,
                    student.Grade,
                    student.StudentName,
                    subject.SubjectName,
                    firstGrade.SemesterGradeValue,
                    secondGrade.SemesterGradeValue,
                    thirdGrade.SemesterGradeValue,
                    finalGrade);
            }

            return resString;
        }
    }

}
