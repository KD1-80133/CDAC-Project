using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnitityModelLib;



namespace RepositoryLib
{
    public interface IDepartmentRepository
    {
        bool Add(Department department);
        bool Modify(Department Department);
        void Remove(int deptid);
        IEnumerable<Department> GetDepartments();

        Department FindById(int deptId);

        //bool Remove(Department Department);

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
            Console.WriteLine(
            db.SaveChanges());
            return true;
        }






        public Department FindById(int deptId)
        {
            return db.Departments.Find(deptId);
        }

        public IEnumerable<Department> GetDepartments()
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



        public void Remove(int deptId)
        {
            Department dept = FindById(deptId);
            Console.WriteLine(dept);
            db.Remove(dept);
            db.SaveChanges();

        }

        /*        public bool Remove(Department department)
        {
            db.Remove(department);
            db.SaveChanges();
            return true;
        }*/
    }
}