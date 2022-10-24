using Dienynas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Repositories
{
    public class TeachersRepository
    {
        public List<Teacher> TeacherList { get; set; }
        public string TeacherDBPath;

        public TeachersRepository(string env)
        {
            TeacherList = new List<Teacher>();
            
            if (env == "prod")
            {
                TeacherDBPath = Path.Combine(new ProjectPath().PathString, @"Data\Prod\", "Teachers.txt");
            }
            else if (env == "test")
            {
                TeacherDBPath = Path.Combine(new ProjectPath().PathString, @"Data\Test\", "Teachers_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }
            int teacherID;
            string teacherName;
            List<int> subjectIDs;
            char gradePrefix;

            char[] possibleGradePrefixes = { 'A', 'B', 'C' };
            DateTime dateAdded;

            string[] RawFile = File.ReadAllLines(TeacherDBPath);
            string[] fileLine;

            foreach (string line in RawFile)
            {
                fileLine = line.Split(";");

                if (
                    int.TryParse(fileLine[0], out teacherID) &&
                    fileLine[1].Length > 0 &&
                    char.TryParse(fileLine[3], out gradePrefix) &&
                    DateTime.TryParse(fileLine[4], out dateAdded)
                    )
                {
                    subjectIDs = fileLine[2].Split(',').Select(subID => Int32.Parse(subID)).ToList();
                    teacherName = fileLine[1];
                    TeacherList.Add(new Teacher(teacherID, teacherName, subjectIDs, gradePrefix, dateAdded));
                }
                //else
                //{
                //ErrorBlinkStyle file pildymas
                //}
            }

        }
        public List<Teacher> Retrieve()
        {
            return TeacherList;
        }
        public Teacher Retrieve(int teacherID)
        {
            return TeacherList.Where(s => s.TeacherID == teacherID).FirstOrDefault();
        }
        public bool CheckTeacherID(int teacherID)
        {
            if (TeacherList.Where(s => s.TeacherID == teacherID).Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
