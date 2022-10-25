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
SemesterEveluationService SemesterEveluation = new SemesterEveluationService(Students, Teachers, Subjects, SubjectMarks, Semesters);
InformationPlotter Information = new InformationPlotter(Students, Teachers, Subjects, SubjectMarks, Semesters);

string userInput = "";
while (userInput != "quit")
{
    Console.WriteLine("Menu:");
    Console.WriteLine("Press 1 to get Student information");
    Console.WriteLine("Press 2 to get Subject information");
    Console.WriteLine("");
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
