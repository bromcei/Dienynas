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
                SemesterDBPath = Path.Combine(@"C:\Users\tomas.ceida\Source\Repos\bromcei\Dienynas\Dienynas\", @"Data\Prod\", "Semesters.txt");
            }
            else if (env == "test")
            {
                SemesterDBPath = Path.Combine(@"C:\Users\tomas.ceida\Source\Repos\bromcei\Dienynas\Dienynas\", @"Data\Test\", "Semesters_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }
            string[] fileLine;
            int semesterID;
            DateTime semesterStartDate;
            DateTime semesterEndDate;
            foreach (string line in File.ReadLines(SemesterDBPath))
            {
                fileLine = line.Split(";");
                if (
                    int.TryParse(fileLine[0], out semesterID) &&
                    DateTime.TryParse(fileLine[2], out semesterStartDate) &&
                    DateTime.TryParse(fileLine[3], out semesterEndDate)
                    )
                {
                    SemesterList.Add(new Semester(semesterID, fileLine[1], semesterStartDate, semesterEndDate, fileLine[4]));
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
