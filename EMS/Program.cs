using Project_logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EMS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger errorLogger = LoggerFactory.GetErrorLogger("file");
            errorLogger.LoggerEntry(new Exception("File error"));

            errorLogger = LoggerFactory.GetErrorLogger("console");
            errorLogger.LoggerEntry(new Exception("Console occurred."));

            errorLogger = LoggerFactory.GetErrorLogger("db");
            errorLogger.LoggerEntry(new Exception("DataBase error ."));
        }
    }
}
