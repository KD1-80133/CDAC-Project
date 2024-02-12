using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    [Table("T_Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EmpId")]
        public int EmpId { get; set; }
        
        [Column("FirstName")]
        public string FirstName { get; set; }
     
        [Column("LastName")]
        public string LastName { get; set; }
       
        [Column("DesignationId")]
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        
        [Column("HireDate")]
        public DateTime HireDate { get; set; }
        
        [Column("IsResigned")]
        public bool IsResigned { get; set; }
       
        [Column("HourlyRate")]
        public int HourlyRate { get; set; }
        
        [Column("DeptId")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        
        [Column("ManagerId")]
        public int ManagerId { get; set; }

        public override string ToString()
        {
            return $"EmpId: {EmpId}, FirstName: {FirstName}, LastName: {LastName}, DesignationId: {DesignationId}, HireDate: {HireDate}, IsResigned: {IsResigned}, HourlyRate: {HourlyRate}, DeptId: {DeptId}, ManagerId: {ManagerId}";
        }

    }
}
