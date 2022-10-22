using Dienynas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Repositories
{
    public class SubjectRepository
    {
        public List<Subject> SubjectList { get; set; }
        public string SubjectDBPath;

        public SubjectRepository()
        {
            SubjectList = new List<Subject>();
            SubjectDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "Subjects.txt");
            string[] fileLine;
            int subjectID;
            string subjectName;
            int gradeID;
            int minNoGrades;

            foreach (string line in File.ReadAllLines(SubjectDBPath))
            {
                fileLine = line.Split(";");

                if (
                    int.TryParse(fileLine[0], out subjectID) &&
                    fileLine[1].Length > 0 &&
                    int.TryParse(fileLine[2], out gradeID) &&
                    int.TryParse(fileLine[3], out minNoGrades)
                    )
                {
                    subjectName = fileLine[1];
                    SubjectList.Add(new Subject(subjectID, subjectName, gradeID, minNoGrades));
                }
                //else
                //{
                //ErrorBlinkStyle file pildymas
                //}
            }

        }
        public List<Subject> Retrieve()
        {
            return SubjectList;
        }
        public Subject Retrieve(int subjectID)
        {
            return SubjectList.Where(s => s.SubjectID == subjectID).FirstOrDefault();
        }
    }
}
