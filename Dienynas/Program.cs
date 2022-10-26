using Dienynas;
using Dienynas.Classes;
using Dienynas.Repositories;
using Dienynas.Services;
using System.Linq.Expressions;


string envName = "prod";
StudentsRepository Students = new StudentsRepository(envName);
TeachersRepository Teachers = new TeachersRepository(envName);
SubjectRepository Subjects = new SubjectRepository(envName);
SubjectMarksRepository SubjectMarks  = new SubjectMarksRepository(envName); 
SemesterRepository Semesters = new SemesterRepository(envName);

StudentsMarkingService StudentsMarking = new StudentsMarkingService(Students, Teachers, Subjects, SubjectMarks);
SemesterEvaluationService SemesterEveluation = new SemesterEvaluationService(Students, Teachers, Subjects, SubjectMarks, Semesters);
InformationPlotter Information = new InformationPlotter(Students, Teachers, Subjects, SubjectMarks, Semesters, SemesterEveluation);

string userInput = "";
while (userInput != "quit")
{
    Console.WriteLine("Menu:");
    Console.WriteLine("Press 1 to list Student information");
    Console.WriteLine("Press 2 to list Subject information");
    Console.WriteLine("Press 3 to get student grades");
    Console.WriteLine("Press 4 to get student final semester Grades");
    Console.WriteLine("Type \"quit\" to quit application");

    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.WriteLine("Input types:");
            Console.WriteLine("all - lists all students");
            Console.WriteLine("Grade No - selected grade students");
            string selectedStudType = Console.ReadLine();
            Console.WriteLine(Information.PlotClassStudents(selectedStudType));
            break;

        case "2":
            Console.WriteLine("Input types:");
            Console.WriteLine("all - lists all subjects");
            Console.WriteLine("Grade No - selected grade subjects");
            string selectedSubType = Console.ReadLine();
            Console.WriteLine(Information.PlotClassSubjects(selectedSubType));
            break;

        case "3":
            Console.WriteLine("Input student ID:");
            Console.WriteLine("studentID - selected student marks");
            int studentID3;
            if(!int.TryParse(Console.ReadLine(), out studentID3))
                {
                Console.WriteLine("Wrong input type, must by int");
                break;
            }

            Console.WriteLine("Input Subject:");
            Console.WriteLine("all - returns all subject marks");
            Console.WriteLine("subjectID value - selected subject marks");
            string SubjectInput = Console.ReadLine();

            if (SubjectInput == "all")
            {
                Console.WriteLine(Information.PlotStudentGrades(studentID3));
            }
            else
            {
                Console.WriteLine(Information.PlotStudentGradesSingleSubject(studentID3, SubjectInput));
            }
            
            break;

        case "4":
            Console.WriteLine("Input student ID:");
            Console.WriteLine("studentID - selected subject marks");
            Console.WriteLine("all - shows all students final grades");

            int studentID4;
            string userInput4 = Console.ReadLine();
            if (int.TryParse(userInput4, out studentID4))
            {
                Console.WriteLine($"{Students.Retrieve(studentID4)} final grades:");
                Console.WriteLine(Information.StudentSemesterGrades(studentID4));
            }
            else if (userInput4 == "all")
            {
                foreach(Student student in Students.Retrieve().OrderBy(s => s.Grade).OrderBy(s => s.StudentName).ToList())
                {
                    Console.WriteLine($"{student.StudentName} final grades:");
                    Console.WriteLine(Information.StudentSemesterGrades(student.StudentID));
                    
                }
            }
            else
            {
                Console.WriteLine("Unknow input value command");
            }

            break;
            

        default:
            // code block
            break;
    }
}




/*
using System.Windows.Forms;



//Forms

namespace Dienynas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
*/
