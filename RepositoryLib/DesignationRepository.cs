using EntityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public  interface IDesignationRepository
    {
        bool Add(Designation designation);
        bool Modify(Designation designation);
        void Remove(int desgId);
        IEnumerable<Designation> GetDesignations();

        Designation FindById(int desgId);
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
            Console.WriteLine(db.SaveChanges());
            return true;
        }
        public Designation FindById(int desgId)
        {
            return db.Designations.Find(desgId);
        }

        

        public IEnumerable<Designation> GetDesignations()
        {
            return db.Designations.ToList<Designation>();

        }

        public bool Modify(Designation designation)
        {
            Designation tobeModify = db.Designations.Where(desg => designation.DesignationId == desg.DesignationId).ToList().FirstOrDefault<Designation>();
            tobeModify.DesignationName = designation.DesignationName;
            db.SaveChanges();
            return true;
        }

        public void Remove(int desgId)
        {
            Designation desg = FindById(desgId);
            Console.WriteLine(desg);
            db.Remove(desg);
            db.SaveChanges();
        }
    }
}
