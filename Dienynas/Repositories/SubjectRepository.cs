﻿using Dienynas.Classes;
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

        public SubjectRepository(string env)
        {
            SubjectList = new List<Subject>();
            
            if (env == "prod")
            {
                SubjectDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Prod\", "Subjects.txt");
            }
            else if (env == "test")
            {
                SubjectDBPath = Path.Combine(Environment.CurrentDirectory, @"Data\Tes\t", "Subjects_test.txt");
            }
            else
            {
                throw new ArgumentException("Bloga pasirinkta env");
            }
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
        public bool CheckSubjectID(int subjectID)
        {
            if (SubjectList.Where(s => s.SubjectID == subjectID).Count() == 1)
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
