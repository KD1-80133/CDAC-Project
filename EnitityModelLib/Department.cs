using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    [Table("T_Department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DeptId")]
        public int DeptId { get; set; }
        [Required]
        [Column("DeptName")]
        public string DeptName { get; set; }
        public override string ToString()
        {
            return $"DeptId: {DeptId}, DeptName: {DeptName}";
        }
    }
}
