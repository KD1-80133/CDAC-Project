using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    public class ErrorLogs
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Method { get; set; }
        public DateTime ErrorOn { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }


        public override string ToString()
        {
            return $"Id: {0}, Source: {1}, Method: {2}, ErrorOn: {3}, Message: {4}, StackTrace: {5}";
        }
    }
}
