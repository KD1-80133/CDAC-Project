using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    public class PasswordHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ChangedOn { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public override string ToString()
        {
            return $"Id: {0}, UserId: {1}, ChangedOn: {2}, OldPassword: {3}, NewPassword: {4}";
        }
    }
}
