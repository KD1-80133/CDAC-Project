using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLib
{
    public class OTPDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OTP { get; set; }
        public DateTime GeneratedOn { get; set; }
        public DateTime ValidTill { get; set; }

        public override string ToString()
        {
            return this.Id + " " + this.UserId + " " + this.OTP + " " + this.GeneratedOn + " " + this.ValidTill;
        }
    }
}
