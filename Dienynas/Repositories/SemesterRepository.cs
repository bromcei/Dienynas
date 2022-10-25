using Dienynas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Repositories
{
    public class SemesterRepository
    {
        public List<Semester> SemesterList { get; set; }
        public string SemesterDBPath { get; set; }
        public SemesterRepository(string env)
        {
            SemesterList = new List<Semester>();
            if (env == "prod")
            {
                SemesterDBPath = Path.Combine(new ProjectPath().PathString, @"Data\Prod\", "Semesters.txt");
            }
            else if (env == "test")
            {
                SemesterDBPath = Path.Combine(new ProjectPath().PathString, @"Data\Test\", "Semesters_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }
            
            int semesterID;
            int semesterNo;
            DateTime semesterStartDate;
            DateTime semesterEndDate;
            string[] RawFile = File.ReadAllLines(SemesterDBPath);
            string[] fileLine;
            bool currYear;

            foreach (string line in RawFile)
            {
                fileLine = line.Split(";");
                if (
                    int.TryParse(fileLine[0], out semesterID) &&
                    int.TryParse(fileLine[1], out semesterNo) &&
                    DateTime.TryParse(fileLine[3], out semesterStartDate) &&
                    DateTime.TryParse(fileLine[4], out semesterEndDate) &&
                    bool.TryParse(fileLine[6], out currYear) 
                    )
                {
                    SemesterList.Add(new Semester(semesterID, semesterNo, fileLine[1], semesterStartDate, semesterEndDate, fileLine[4], currYear));
                }
            }

        }
        public List<Semester> Retrieve()
        {
            return SemesterList;
        }
        public Semester Retrieve(int semesterID)
        {
            return SemesterList.Where(sem => sem.SemesterID == semesterID).FirstOrDefault();
        }
        public Semester RetrieveCurrentByNo(int semesterNo)
        {
            return SemesterList.Where(sem => sem.SemesterNo == semesterNo && sem.CurrentYear == true).FirstOrDefault();
        }
        public Semester Retrieve(DateTime markDate)
        {
            return SemesterList.Where(sem => sem.SemesterStart <= markDate && sem.SemesterEnd >= markDate).FirstOrDefault();
        }
        public List<DateTime> SemesterDatesList(int semesterID)
        {
            List<DateTime> datesList = new List<DateTime>();
            Semester semester = Retrieve(semesterID);
            for (DateTime dt = semester.SemesterStart; dt <= semester.SemesterEnd; dt = dt.AddDays(1))
            {
                datesList.Add(dt);
            }
            return datesList;
        }
    }
}
