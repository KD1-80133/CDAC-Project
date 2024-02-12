using EntityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IDesignationRepository
    {
        bool Add(EntityModelLib.Designation designation);
        bool Modify(EntityModelLib.Designation designation);
        bool Remove(int DesignationId);
        IEnumerable<EntityModelLib.Designation> GetAllDesignations();
    }

    public class DesignationRepository : IDesignationRepository
    {
        ProjectContext db;
        public DesignationRepository()
        {
            db = new ProjectContext();
        }

        public bool Add(Designation designation)
        {
            db.Add(designation);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Designation> GetAllDesignations()
        {
            return db.Designations.ToList<Designation>();
        }

        public bool Modify(Designation designation)
        {
            Designation tobeModify = db.Designations.Where(desgn => designation.DesignationId == desgn.DesignationId).ToList().FirstOrDefault<Designation>();
            tobeModify.DesignationName = designation.DesignationName;
            db.SaveChanges();
            return true;
        }


        public Designation FindById(int DesignationId)
        {
            return db.Designations.Find(DesignationId);
        }
        public bool Remove(int DesignationId)
        {
            Designation desg = FindById(DesignationId);
            db.Designations.Remove(desg);
            db.SaveChanges();
            return true;
        }
    }
}
