using EntityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IProjectRepository
    {
        bool Add(Project project);

        bool Remove(int projId);

        bool Modify(Project project);

        IEnumerable<Project> GetProjects();

        TimeSpan GetProjectDays(int projId);

        Project FindById(int projId);
    }

    public class ProjectRepository : IProjectRepository
    {
        ProjectDbContext db;

        public ProjectRepository()
        {
            db = new ProjectDbContext();
        }
        public bool Add(Project project)
        {
            db.Add(project);
            int count=db.SaveChanges();
            if(count==1)
              return true;
            return false;
        }

        public Project FindById(int projId)
        {
            return db.Projects.Find(projId);
        }

        public TimeSpan GetProjectDays(int projId)
        {
            Project proj = FindById(projId);
            var days = proj.StartDate.Subtract(proj.EndDate);
            return days;
        }

        public IEnumerable<Project> GetProjects()
        {
            return db.Projects.ToList<Project>();

        }

        public bool Modify(Project project)
        {
            Project tobeModify = db.Projects.Where(proj => project.ProjectId == proj.ProjectId).ToList().FirstOrDefault<Project>();
            tobeModify.ProjectId = project.ProjectId;
            db.SaveChanges();
            return true;
        }

        public bool Remove(int projId)
        {
            Project proj = FindById(projId);
            Console.WriteLine(proj);
            db.Remove(proj);
            int count=db.SaveChanges();
            if(count==1)
            {
                return true;
            }
            return false;
        }
    }
}
