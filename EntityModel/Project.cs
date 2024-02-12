using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLib
{
    [Table("T_Project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProjectId")]
        public int ProjectId { get; set; }
        [Required]
        [Column("Title")]
        public string Title { get; set; }
        [Required]
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Required]
        [Column("EndDate")]
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return this.ProjectId + " " + this.Title + " " + this.StartDate + " " + this.EndDate;
        }
    }
}
