﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLib
{
    [Table("T_Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EmpId")]
        public int EmpId { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("DesignationId")]
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }

        [Required]
        [Column("HireDate")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("IsResigned")]
        public bool IsResigned  { get; set; }

        [Required]
        [Column("HourlyRate")]
        public int HourlyRate { get; set; }

        [Required]
        [Column("DepartmentId")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [Column("ManagerId")]
        public int ManagerId { get; set; }

        [Required]
        [Column("UserId")]
        public int UserId { get; set; }
    }
}