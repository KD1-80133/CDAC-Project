using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    [Table("T_Designation")]
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DesignationId")]
        public int DesignationId { get; set; }
        [Required]
        [Column("DesignationName")]
        public string DesignationName { get; set; }

        public override string ToString()
        {
            return $"DesignationId: {DesignationId}, DesignationName: {DesignationName}";
        }

    }
}
