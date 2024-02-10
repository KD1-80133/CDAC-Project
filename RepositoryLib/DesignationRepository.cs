using EnitityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public  interface IDesignationRepository
    {
        bool Add(EnitityModelLib.Designation designation);
        bool Modify(EnitityModelLib.Designation designation);
        IEnumerable<EnitityModelLib.Designation> GetDesignations();
        bool Remove(int DesignationId);
    }
    public class DesignationRepository : IDesignationRepository
    {
        ProjectDbContext db;
        public DesignationRepository()
        {
            db = new ProjectDbContext();
        }
        public bool Add(Designation designation)
        {
            db.Add(designation);
            //db.SaveChanges();
            return true;
        }

        public IEnumerable<Designation> GetDesignations()
        {
            return db.Designations.ToList<Designation>();
        }

        public bool Modify(Designation designation)
        {
            Designation tobeModify = db.Designations.Where(desi => designation.DesignationId == desi.DesignationId).ToList().FirstOrDefault<Designation>();
            tobeModify.DesignationName = designation.DesignationName;
            db.SaveChanges();
            return true;
        }

        public bool Remove(int DesignationId)
        {
            db.Departments.Remove(db.Departments.Find(DesignationId));
            return true;
        }
    }
}
