using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_logger
{
    public  class LoggerConsole : Logger
    {

        public bool LoggerEntry(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
