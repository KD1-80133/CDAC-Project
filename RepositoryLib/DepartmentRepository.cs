﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModelLib;


namespace RepositoryLib
{
    public  interface IDepartmentRepository
    {
        bool Add(Department department);
        bool Modify(Department Department);
        bool Remove(Department Department);
        IEnumerable<Department> GetDepartments();

        Department FindById(int deptId);
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

        

        /*public bool Delete(int deptId)
        {
            db.Departments.Remove(db.Departments.Find(deptId));
            return true;
        }*/
        public bool Remove(Department department)
        {
            db.Remove(department);
            db.SaveChanges();
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
    }
}
