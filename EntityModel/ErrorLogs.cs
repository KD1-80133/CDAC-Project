using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLib
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
            return this.Id+" "+this.Source+" "+this.Method+" "+this.ErrorOn+" "+this.Message+" "+this.StackTrace;
        }

    }
}
