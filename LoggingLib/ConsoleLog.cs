using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLib
{
    public class ConsoleLog : ILog
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
