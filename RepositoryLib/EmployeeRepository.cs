using EnitityModelLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        void Modify(Employee employee);

        Employee FindById(int empId);
        bool Remove(int EmpId);

    }

    public class EmployeeRepository : IEmployeeRepository
    {
        ProjectDbContext db;
        public EmployeeRepository()
        {
            db = new ProjectDbContext();
        }
        public bool Add(Employee employee)
        {
            db.Add(employee);
            db.SaveChanges();
            return true;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees.ToList<Employee>();

        }

        public void Modify(Employee employee)
        {
            Console.WriteLine(employee);
            Employee tobeModify = db.Employees.Where(emps => employee.DeptId == emps.DeptId).ToList().FirstOrDefault<Employee>();
            tobeModify.FirstName = employee.FirstName;
            tobeModify.LastName = employee.LastName;
            tobeModify.DesignationId = employee.DesignationId;
            tobeModify.IsResigned = employee.IsResigned;
            /* tobeModify.HourlyRate = employee.HourlyRate;
             tobeModify.DeptId = employee.DeptId;
             tobeModify.ManagerId = employee.ManagerId;*/
            Console.WriteLine(tobeModify);
            db.SaveChanges();

        }
        public Employee FindById(int empId)
        {
            return db.Employees.Find(empId);
        }
        public bool Remove(int EmpId)
        {
            Employee emp = FindById(EmpId);
            db.Remove(emp);
            db.SaveChanges();
            return true;
        }
    }
}