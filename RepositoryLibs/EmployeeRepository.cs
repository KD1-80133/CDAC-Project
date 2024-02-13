using EntityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IEmployeeRepository
    {
        bool Add(EntityModelLib.Employee employee);
        void Modify(EntityModelLib.Employee employee);
        bool Remove(int EmpId);
        IEnumerable<EntityModelLib.Employee> GetAllEmployees();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        ProjectContext db;
        public EmployeeRepository()
        {
            db = new ProjectContext();
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
            Employee tobeModify = db.Employees.Where(emps => employee.DepartmentId == emps.DepartmentId).ToList().FirstOrDefault<Employee>();
            tobeModify.FirstName = employee.FirstName;
            tobeModify.LastName = employee.LastName;
            tobeModify.DesignationId = employee.DesignationId;
            tobeModify.IsResigned = employee.IsResigned;
            tobeModify.UserId = employee.UserId;
            /* tobeModify.HourlyRate = employee.HourlyRate;
             tobeModify.DeptId = employee.DeptId;
             tobeModify.ManagerId = employee.ManagerId;*/
            Console.WriteLine(tobeModify);
            db.SaveChanges();

        }

        public Employee FindById(int EmpId)
        {
            return db.Employees.Find(EmpId);
        }
        public bool Remove(int EmpId)
        {
            Employee emp = FindById(EmpId);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return true;
        }
    }
}
