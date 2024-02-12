using EntityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IProjectMembersRepository
    {
        bool Add(EntityModelLib.ProjectMembers projectMembers);
        void Modify(EntityModelLib.ProjectMembers projectMembers);
        bool Remove(int ProjId);
        IEnumerable<EntityModelLib.ProjectMembers> GetAllProjectMembers();
        ProjectMembers FindById(int projId);
    }

    public class ProjectMembersRepository : IProjectMembersRepository
    {
        ProjectContext db;
        public ProjectMembersRepository()
        {
            db = new ProjectContext();
        }
        public bool Add(ProjectMembers projectMembers)
        {
            db.Add(projectMembers);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<ProjectMembers> GetAllProjectMembers()
        {
            return db.ProjectMembers.ToList<ProjectMembers>();
        }

        public void Modify(ProjectMembers projectMembers)
        {
            Console.WriteLine(projectMembers);
            ProjectMembers tobeModify = db.ProjectMembers.Where(projmem => projectMembers.ProjMemberId == projmem.ProjMemberId).ToList().FirstOrDefault<ProjectMembers>();
            tobeModify.UserId = projectMembers.UserId;
            tobeModify.ProjectId = projectMembers.ProjectId;
            Console.WriteLine(tobeModify);
            db.SaveChanges();
            
        }

        public ProjectMembers FindById(int projId)
        {
            return db.ProjectMembers.Find(projId);
        }
        public bool Remove(int projId)
        {
            ProjectMembers projMembers = FindById(projId);
            db.ProjectMembers.Remove(projMembers);
            db.SaveChanges();
            return true;
        }
    }
}
