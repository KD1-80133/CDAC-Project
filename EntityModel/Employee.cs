using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace EntityModelLib
{

    [Table("T_Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EmpId")]
        public int EmpId { get; set; }
        //[Required]
        [Column("FirstName")]
        public string FirstName { get; set; }
        //[Required]
        [Column("LastName")]
        public string LastName { get; set; }
        //[Required]
        [Column("DesignationId")]
        [ForeignKey("DesignationId")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        //[Required]
        [Column("HireDate")]
        public DateTime HireDate { get; set; }
        //[Required]
        [Column("IsResigned")]
        public bool IsResigned { get; set; }
        //[Required]
        [Column("HourlyRate")]
        public int HourlyRate { get; set; }
        //[Required]
        [Column("DeptId")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        //[Required]
        [Column("ManagerId")]
        public int ManagerId { get; set; }

        public override string ToString()
        {
            return this.EmpId.ToString() + " " + this.FirstName + " " + this.LastName + " " + this.DesignationId
                + " " + this.HireDate + " " + this.IsResigned + " " + this.HourlyRate.ToString()
                + " " + this.DeptId;

        }
    }
}


