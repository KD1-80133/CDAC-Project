using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public override string ToString()
        {
            return $"{RoleId}: {RoleName}";
        }
    }
}
