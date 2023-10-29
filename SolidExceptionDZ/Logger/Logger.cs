using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExceptionDZ.Logger
{
    public class Logger : ILogger
    {
        public void LogWarning(string exc)
        {
            Console.WriteLine(exc);
        }

        public void LogIndormation(string info)
        {
            Console.WriteLine(info);
        }
    }
}
