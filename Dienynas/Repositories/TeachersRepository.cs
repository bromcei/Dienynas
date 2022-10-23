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
                TeacherDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Prod\", "Teachers.txt");
            }
            else if (env == "test")
            {
                TeacherDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Test\", "Teachers_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }
            int teacherID;
            string teacherName;
            List<int> subjectIDs;
            int perceptorGrade;
            char gradePrefix;
            string[] fileLine;
            char[] possibleGradePrefixes = { 'A', 'B', 'C' };
            DateTime dateAdded;

            foreach (string line in File.ReadAllLines(TeacherDBPath))
            {
                fileLine = line.Split(";");
                gradePrefix = '-';
                if (
                    int.TryParse(fileLine[0], out teacherID) &&
                    fileLine[1].Length > 0 &&
                    int.TryParse(fileLine[3], out perceptorGrade) &&
                    possibleGradePrefixes.Contains(gradePrefix) &&
                    DateTime.TryParse(fileLine[4], out dateAdded)
                    )
                {
                    subjectIDs = fileLine[2].Split(',').Select(subID => Int32.Parse(subID)).ToList();
                    teacherName = fileLine[1];
                    TeacherList.Add(new Teacher(teacherID, teacherName, subjectIDs, perceptorGrade, gradePrefix, dateAdded));
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
