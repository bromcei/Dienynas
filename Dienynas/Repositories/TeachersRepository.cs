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
        List<Teacher> TeacherList { get; set; }
        string TeacherDBPath;

        public TeachersRepository()
        {
            TeacherList = new List<Teacher>();
            TeacherDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "Teachers.txt");
            int teacherID;
            string teacherName;
            int subjectID;
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
                    int.TryParse(fileLine[2], out subjectID) &&
                    int.TryParse(fileLine[3], out perceptorGrade) &&
                    possibleGradePrefixes.Contains(gradePrefix) &&
                    DateTime.TryParse(fileLine[4], out dateAdded)
                    )
                {
                    teacherName = fileLine[1];
                    TeacherList.Add(new Teacher(teacherID, teacherName, subjectID, perceptorGrade, gradePrefix, dateAdded));
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
        public Teacher Retrieve(int studentID)
        {
            return TeacherList.Where(s => s.StudentID == studentID).FirstOrDefault();
        }
    }
