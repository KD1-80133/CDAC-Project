using EntityModelLib;
using RepositoryLib;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace EMS
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*IMembershipRepository mbr = new MembershipRepository();
            Console.WriteLine(
            mbr.ValidateUser("user1@example.com","nopassword"));*/

            /*IDepartmentRepository department = new DepartmentRepository();
            Department dept = new Department() { DeptName = "fin" };
            department.Add(dept);*/

            /* IDepartmentRepository department = new DepartmentRepository();
             Department dept = new Department() { DeptId = 1 };
             department.Remove(dept);*/
            /*IDepartmentRepository department = new DepartmentRepository();
            Department dept = new Department() {DeptId=2 ,DeptName = "customer relation" };
            department.Modify(dept);*/

            /*            IDepartmentRepository department = new DepartmentRepository();
                        department.Remove(1007);*/

            /*IDesignationRepository designation = new DesignationRepository();
            Designation desg = new Designation() { DesignationName = "DBA" };
            designation.Add(desg);*/

            /*IDesignationRepository designation = new DesignationRepository();
            Console.WriteLine( designation.FindById(4));*/

            /*IDesignationRepository designation = new DesignationRepository();
            IEnumerable<Designation> desgList  =designation.GetDesignations();
            foreach (var item in desgList)
            {
                Console.WriteLine(item);

            }*/
            /*IDesignationRepository designation = new DesignationRepository();
            designation.Remove(3);
*/

            IDesignationRepository designation = new DesignationRepository();
            Designation desg = new Designation() { DesignationId = 1, DesignationName = "project manager" };
            designation.Modify(desg);

        }
    }
}
