using EntityModelLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=task_mgt;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMembers> ProjectMembers { get; set; }

    }
}
