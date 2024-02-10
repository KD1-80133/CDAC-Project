using EnitityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IDepartmentRepository
    {
        bool Add(EnitityModelLib.Department department);
        bool Modify(EnitityModelLib.Department department);
        bool Remove(int deptId);

        IEnumerable<EnitityModelLib.Department> GetAllDepartments();


    }

    public class DepartmentRepository : IDepartmentRepository
    {
        ProjectDbContext db;
        public DepartmentRepository()
        {
            db = new ProjectDbContext();
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
            Department tobeModify= db.Departments.Where(dept=>department.DeptId==dept.DeptId).ToList().FirstOrDefault<Department>();
            tobeModify.DeptName = department.DeptName;
            db.SaveChanges();
            return true;
        }

        public bool Remove(int deptId)
        {
            db.Departments.Remove(db.Departments.Find(deptId));
            return true;
        }
    }
}
