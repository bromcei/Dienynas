using Dienynas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Repositories
{
    public class SubjectMarksRepository
    {
        public List<SubjectMark> SubjectMarksList { get; set; }
        public string SubjectMarksDBPath;

        public SubjectMarksRepository(string env)
        {
            SubjectMarksList = new List<SubjectMark>();
            
            if (env == "prod")
            {
                SubjectMarksDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Prod", "SubjectMarks.txt");
            }
            else if (env == "test")
            {
                SubjectMarksDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Test", "SubjectMarks_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }

            string[] fileLine;
            int markID;
            int studentID;
            int teacherID;
            int subjectID;
            double markValue;
            DateTime dateAdded;

            foreach (string line in File.ReadAllLines(SubjectMarksDBPath))
            {
                fileLine = line.Split(";");

                if (
                    int.TryParse(fileLine[0], out markID) &&
                    int.TryParse(fileLine[1], out studentID) &&
                    int.TryParse(fileLine[2], out teacherID) &&
                    int.TryParse(fileLine[3], out subjectID) &&
                    double.TryParse(fileLine[4], out markValue) &&
                    DateTime.TryParse(fileLine[5], out dateAdded)
                    )
                {
                    SubjectMarksList.Add(new SubjectMark(markID, studentID, teacherID, subjectID, markValue, dateAdded));
                }
                //else
                //{
                    //ErrorBlinkStyle file pildymas
                //}
            }
            
        }
        public List<SubjectMark> Retrieve()
        {
            return SubjectMarksList;
        }
        public SubjectMark Retrieve(int markID)
        {
            return SubjectMarksList.Where(s => s.MarkID == markID).FirstOrDefault();
        }
        public int GetMaxMarkID()
        {
            return SubjectMarksList.Max(marks => marks.MarkID);
        }
    }

}
