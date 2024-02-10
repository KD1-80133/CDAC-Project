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
        bool Modify(Employee employee);
        bool Remove(int EmpId);
        IEnumerable<Employee> GetAllEmployees();

    }
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public bool Modify(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int EmpId)
        {
            throw new NotImplementedException();
        }
    }
}
