using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
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
            return $"Id: {Id}, UserId: {UserId}, OTP: {OTP}, GeneratedOn: {GeneratedOn}, ValidTill: {ValidTill}"; 
            }
    }
}
