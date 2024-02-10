using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class User
    {
        public User()
        {

        }

        public User(string EmailId, string MobileNo, string Name, int UserId)
        {
            this.EmailId = EmailId;
            this.MobileNo = MobileNo;
            this.Name = Name;
            this.UserId = UserId;
        }
        public int UserId { get; set; }
        public string  EmailId { get; set; }
        public string Password { get; set; }

        public string MobileNo { get; set; }
        public bool IsOnline { get; set; }

        public bool IsLocked { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }

        public string AdharNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return this.UserId + " " + this.EmailId + " " + this.Password + " " + this.MobileNo + " " + this.IsOnline + " " + this.IsLocked + " " + this.RoleId + " " + this.Name +" "+ this.AdharNumber+" "+this.Address;
        }



    }
}
