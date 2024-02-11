using EntityModelLib;
using EntityModelsLib;
using Project_logger;
using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EMS
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Logger errorLogger = LoggerFactory.GetErrorLogger("file");
            //errorLogger.LoggerEntry(new Exception("File error"));

            //errorLogger = LoggerFactory.GetErrorLogger("console");
            //errorLogger.LoggerEntry(new Exception("Console occurred."));

            //errorLogger = LoggerFactory.GetErrorLogger("db");
            //errorLogger.LoggerEntry(new Exception("DataBase error ."));

            //IDepartmentRepository dept = new DepartmentRepository();
            //Department department = new Department() { DeptName = "Development" };
            //dept.Add(department);
            // dept.Modify(new Department() { DeptId = 2, DeptName = "HR123" });
            //dept.Remove(1);

            //IDesignationRepository desgn = new DesignationRepository();
            //Designation designation = new Designation() { DesignationName = "Team Leader" };
            //desgn.Add(designation);
            //desgn.Modify(new Designation { DesignationId = 1, DesignationName = "Team Head" });
            // desgn.Remove(1);

            IEmployeeRepository emp = new EmployeeRepository();
            Employee employee = new Employee() { FirstName="Nivedita",LastName="patil",DesignationId=1,  HireDate= DateTime.Now ,IsResigned=false,HourlyRate=800,DepartmentId=1,  ManagerId=1};
            //emp.Add(employee);

            emp.Modify(new Employee() { FirstName = "Nivedita", LastName = "chougule", IsResigned = true, HourlyRate = 800, ManagerId = 2 });













            //MembershipRepository repo = new MembershipRepository();
            //repo.ChangePassword("nivedita.patil96@gmail.com", "nivedita", "pratik");


            //MembershipRepository repo = new MembershipRepository();
            //repo.CreateUser("akanksha", "akkki", "9874563214", "akanksha@gmail.com");


            //MembershipRepository repo = new MembershipRepository();
            //repo.DeleteUser("akanksha@gmail.com");


            //MembershipRepository repo = new MembershipRepository();
            //string result = repo.GenerateOTP("akanksha@gmail.com");
            //Console.WriteLine(result);

            //MembershipRepository repo = new MembershipRepository();
            //repo.GetAllUsers();

            //MembershipRepository repo = new MembershipRepository();
            //int count=repo.GetNumberOfUsersOnline();
            //Console.WriteLine(count);

            //MembershipRepository repo = new MembershipRepository();
            //User user=repo.GetUserByEmail("nivedita@gmail.com");
            //Console.WriteLine(user.ToString());

            //MembershipRepository repo = new MembershipRepository();
            //User user = repo.GetUserByMobileNo("8888135978");
            //Console.WriteLine(user.ToString());

            //MembershipRepository repo = new MembershipRepository();
            //bool result=repo.LockUser("akanksha@gmail.com");
            //Console.WriteLine(result);

            //MembershipRepository repo1 = new MembershipRepository();
            //bool result1 = repo1.ResetPassword("akanksha@gmail.com", "DA8F5", "mule");
            //Console.WriteLine(result1);

            //MembershipRepository repo1 = new MembershipRepository();
            //bool result1=repo1.UnlockUser("akanksha@gmail.com");
            //Console.WriteLine(result1);

            //MembershipRepository repo1 = new MembershipRepository();
            //bool result=repo1.UpdateUser(new User("nivedita.patil96@gmail.com","9975072126","shital",2));
            //Console.WriteLine(result);

            //MembershipRepository repo1 = new MembershipRepository();
            //bool result = repo1.ValidateUser("nivedita.patil96@gmail.com", "nivu");
            //Console.WriteLine(result);
        }
    }

}
