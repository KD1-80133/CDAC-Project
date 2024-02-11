using EntityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IDepartmentRepository
    {
        bool Add(EntityModelLib.Department department);
        bool Modify(EntityModelLib.Department department);
        bool Remove(int DeptId);
        IEnumerable<EntityModelLib.Department> GetAllDepartments();
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        ProjectContext db;
        public DepartmentRepository()
        {
            db = new ProjectContext();
        }

        public bool Add(Department department)
        {
            db.Add(department);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return db.Departments.ToList<Department>();
        }

        public bool Modify(Department department)
        {
            Department tobeModify = db.Departments.Where(dept => department.DeptId == dept.DeptId).ToList().FirstOrDefault<Department>();
            tobeModify.DeptName = department.DeptName;
            db.SaveChanges();
            return true;
        }

        public bool Remove(int DeptId)
        {
            db.Departments.Remove(db.Departments.Find(DeptId));
            return true;
        }
    }
}
