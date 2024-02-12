using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityModelLib
{
    [Table("T_Task")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TaskId")]
        public int TaskId { get; set; }
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Project")]
        [Column("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [Required]
        [Column("TaskDescription")]
        public string TaskDescription { get; set; }
        [Required]
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Required]
        [Column("EndDate")]
        public DateTime EndDate { get; set; }
        [Required]
        [Column("WorkHours")]
        public int WorkHours { get; set; }
        [Required]
        [Column("Status")]
        public string Status { get; set; }
        public override string ToString()
        {
            return $"TaskId: {TaskId}, UserId: {UserId}, ProjectId: {ProjectId}, TaskDescription: {TaskDescription}, StartDate: {StartDate}, EndDate: {EndDate}, WorkHours: {WorkHours}, Status: {Status}";
        }
    }
}
