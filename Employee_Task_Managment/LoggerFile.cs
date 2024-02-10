using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_logger
{
    public  class LoggerFile : Logger
    {
        public LoggerFile()
        {
            FilePath = @"C:\Users\Akanksha\Desktop\Employee_Task_Management\Logger.txt";
        }
        public string FilePath { get; set; }
        public bool LoggerEntry(Exception e)
        {
            FileStream fs = null;
            if (File.Exists(FilePath))
            {
                fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            }
            StreamWriter sw = new StreamWriter(fs);


            sw.WriteLine(e.Message);
            sw.Close();
            fs.Close();

            return true;
        }

    }
}
