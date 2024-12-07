using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLib
{
    class FileLog : ILog
    {
       string filePath;

        public FileLog(string filePath)
        {
            this.filePath = filePath;
        }

        public void Print(string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true)) 
            {
                writer.WriteLine(message);
            }
        }
    }
}
