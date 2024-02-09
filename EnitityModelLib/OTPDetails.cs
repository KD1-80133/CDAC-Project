using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    public class OTPDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? OTP { get; set; }
        public DateTime GeneratedOn { get; set; }
        public DateTime ValidTill { get; set; }

        public override string ToString()
        {
            return $"Id: {0}, UserId: {1}, OTP: {2}, GeneratedOn: {3}, ValidTill: {4}";
        }
    }
}
