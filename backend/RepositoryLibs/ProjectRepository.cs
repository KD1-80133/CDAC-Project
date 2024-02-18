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
        bool Add(EntityModelLib.Project project);
        bool Modify(EntityModelLib.Project project);
        bool Remove(int projectId);
        IEnumerable<EntityModelLib.Project> GetAllProjects();
        Project FindById(int ProjId);
    }

    public class ProjectRepository : IProjectRepository
    {
        ProjectContext db;
        public ProjectRepository()
        {
            db = new ProjectContext();
        }
        public bool Add(Project project)
        {
            db.Add(project);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return db.Projects.ToList<Project>();
        }

        public bool Modify(Project project)
        {
            Console.WriteLine(project);
            Project tobeModify = db.Projects.Where(proj => project.ProjectId == proj.ProjectId).ToList().FirstOrDefault<Project>();
            tobeModify.Title = project.Title;
            tobeModify.StartDate = project.StartDate;
            tobeModify.EndDate = project.EndDate;
            db.SaveChanges();
            return true;
        }

        public Project FindById(int ProjId)
        {
            return db.Projects.Find(ProjId);
        }
        public bool Remove(int ProjId)
        {
            Project project = FindById(ProjId);
            db.Projects.Remove(project);
            db.SaveChanges();
            return true;
        }
    }
}
