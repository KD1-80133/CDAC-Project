﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelLib
{
    public class ProjectMembers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProjMemberId")]
        public int ProjMemberId { get; set; }
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }
        [Required]
        [Column("ProjectId")]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public override string ToString()
        {
            return this.ProjMemberId + " " + this.UserId + " " + this.ProjectId + " " + this.Project;
        }
    }
}
