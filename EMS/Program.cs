using Project_logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLib;
using EnitityModelLib;

namespace EMS
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IDepartmentRepository dept = new DepartmentRepository();

            //Department department = new Department() { DeptId=1, DeptName = "HR 123" };
            //dept.Modify(department);
            IDesignationRepository desi = new DesignationRepository();
            Designation designation = new Designation() { DesignationId=2,DesignationName = "Manager" };
            desi.Modify(designation);

        }
    }
}
