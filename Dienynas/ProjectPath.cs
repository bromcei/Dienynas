using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dienynas
{
    public class ProjectPath
    {
        public string PathString { get; set; }

        public ProjectPath()
        {
            PathString = Directory.GetCurrentDirectory().Replace(@"bin\Debug\net6.0-windows", "");
        }
    }
    
}
