using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_logger
{
    public class LoggerFactory
    {
        public static Logger ErrorLogger;

        public static Logger GetErrorLogger(String LoggerType)
        {
            if (LoggerType.ToLower().Equals("file"))
                return new LoggerFile();

            else if (LoggerType.ToLower().Equals("console"))
                return new LoggerConsole();
            else if (LoggerType.ToLower().Equals("db"))
                return new LoggerDB();

            return ErrorLogger;
        }
    }
}

