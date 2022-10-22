using Dienynas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas.Services
{
    public class StudentsGradingService
    {
        public StudentsRepository Students { get; set; }
        public TeachersRepository Teachers { get; set; }
        public SubjectMarksRepository SubjectMarks { get; set; }


    }
}
