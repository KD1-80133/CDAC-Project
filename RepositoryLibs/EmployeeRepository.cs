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
        bool Modify(EntityModelLib.Employee employee);
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

        public bool Modify(Employee employee)
        {
            Employee tobeModify = db.Employees.Where(emp => employee.EmpId == emp.EmpId).ToList().FirstOrDefault<Employee>();
            tobeModify.FirstName = employee.FirstName;
            tobeModify.LastName = employee.LastName;
            tobeModify.HireDate = employee.HireDate;
            tobeModify.IsResigned = employee.IsResigned;
            tobeModify.HourlyRate = employee.HourlyRate;
            tobeModify.ManagerId = employee.ManagerId;
            db.SaveChanges();
            return true;
        }

        public bool Remove(int EmpId)
        {
            db.Employees.Remove(db.Employees.Find(EmpId));
            return true;
        }
    }
}
