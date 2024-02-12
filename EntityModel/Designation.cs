using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLib
{
    [Table("T_Designation")]
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        public override string ToString()
        {
            return this.DesignationId + " " + this.DesignationName;
        }

    }

    
}
