using EntityModelLib;
using RepositoryLib;

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

            IDepartmentRepository department = new DepartmentRepository();
            Department dept = new Department() { DeptId = 1 };
            department.Remove(dept);
        }
    }
}
