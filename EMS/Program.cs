using EnitityModelLib;
using Project_logger;
using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = EnitityModelLib.Task;



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
            ////desgn.Add(designation);
            ////desgn.Modify(new Designation { DesignationId = 1, DesignationName = "Team Head" });
            //desgn.Remove(1);





            //   IEmployeeRepository emp = new EmployeeRepository();
            ////   Employee employee = new Employee() { FirstName = "Nivedita", LastName = "patil", DesignationId = 1, HireDate = DateTime.Now, IsResigned = false, HourlyRate = 800, DepartmentId = 1, ManagerId = 1 };
            //   //emp.Add(employee);

            //   emp.Modify(new Employee() { FirstName = "Nivedita", LastName = "chougule", IsResigned = true, HourlyRate = 800, ManagerId = 2 });




            //IEmployeeRepository emp = new EmployeeRepository();
            //emp.Modify(new Employee() { FirstName = "Nivedita", LastName = "chougule", IsResigned = true, HourlyRate = 800, ManagerId = 2 });




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


            /*IMembershipRepository mbr = new MembershipRepository();
            Console.WriteLine(
            mbr.ValidateUser("user1@example.com","nopassword"));*/

            //IDepartmentRepository department = new DepartmentRepository();
            //Department dept = new Department() { DeptName = "fin" };
            //department.Add(dept);

            //IDepartmentRepository department = new DepartmentRepository();
            //department.Remove(1);
            //IDepartmentRepository department = new DepartmentRepository();
            //Department dept = new Department() {DeptId=2 ,DeptName = "customer relation" };
            //department.Modify(dept);

            //IDepartmentRepository department = new DepartmentRepository();
            //IEnumerable<Department> deptList = department.GetDepartments();
            //foreach (var item in deptList)
            //{
            //    Console.WriteLine(item);

            //}

            //IDesignationRepository designation = new DesignationRepository();
            //Designation desg = new Designation() { DesignationName = "DBA" };
            //designation.Add(desg);

            //IDesignationRepository designation = new DesignationRepository();
            //Console.WriteLine( designation.FindById(4));

            //IDesignationRepository designation = new DesignationRepository();
            //IEnumerable<Designation> desgList  =designation.GetDesignations();
            //foreach (var item in desgList)
            //{
            //    Console.WriteLine(item);

            //}

            //IDesignationRepository designation = new DesignationRepository();
            //designation.Remove(2);


            //IDesignationRepository designation = new DesignationRepository();
            //Designation desg = new Designation() { DesignationId = 1, DesignationName = "project manager" };
            //designation.Modify(desg);

            //IEmployeeRepository employee = new EmployeeRepository();
            //Employee emp = new Employee() { FirstName = "Salman", LastName = "Khan",DesignationId=1,DeptId=3,IsResigned= false ,HourlyRate=5000,ManagerId=2,HireDate=new DateTime(2005,10,1)};
            //employee.Add(emp);

            /*            IEmployeeRepository employee = new EmployeeRepository();
                        IEnumerable<Employee> emps=employee.GetAllEmployees();
                        foreach (var emp in emps)
                        {
                            Console.WriteLine(emp);
                        }
            */

            /*IEmployeeRepository employee = new EmployeeRepository();
            Console.WriteLine( employee.FindById(6));*/

            /*             IEmployeeRepository employee = new EmployeeRepository();
                           employee.Remove(7);*/

            /* IEmployeeRepository employee = new EmployeeRepository();
              Employee emp = new Employee { EmpId = 6, FirstName = "DB", LastName = "Admin", DesignationId = 1, DeptId = 1, IsResigned = false, HourlyRate = 3000, ManagerId = 1 };
              employee.Modify(emp);*/


            //----------BankAccount-------------//
            //-------ADD AccountDetails--------//
            //IBankAccountRepository bankAccount = new BankAccountRepository();
            //BankAccount bank = new BankAccount() { AccountNo=1,AccountHolderName="Akanksha",AccountType= "Savings", BankName = "SBI", IFSCCode = 123456,UserId=2 };
            //bankAccount.Add(bank);



            // Modifying a BankAccount
            //IBankAccountRepository bankAccountRepository = new BankAccountRepository();
            //BankAccount bankAccount = new BankAccount() { AccountNo = 1, AccountHolderName = "Aknksha1", AccountType = "Savings", BankName = "BOI", IFSCCode = 654321, UserId = 3 };
            //bankAccountRepository.Modify(bankAccount);



            // BankAccount list
            //IBankAccountRepository bankAccountRepository = new BankAccountRepository();
            //IEnumerable<BankAccount> bankAccounts = bankAccountRepository.GetAllAccount();

            //foreach (var bankAccount in bankAccounts)
            //{
            //    Console.WriteLine(bankAccount);
            //}

            //find By AccountNo
            //IBankAccountRepository bankAccountRepository = new BankAccountRepository();
            //BankAccount bankAccount = bankAccountRepository.FindById(1);


            //remove bankaccount

            //IBankAccountRepository bankAccountRepository = new BankAccountRepository();
            //bool removed = bankAccountRepository.Remove(1);

            //-------------Task--------//
            //Add Task
            ITaskRepository taskRepository = new TaskRepository();
            Task task = new Task()
            {
                UserId = 1,
                ProjectId = 1,
                TaskDescription = "Sample Task",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                WorkHours = new TimeOnly(8, 0),
                Status = "Open"
            };
            taskRepository.Add(task);
            //Remove Task


            //Modify Task

            //Find By TAsk Id

            //Gat All Task




        }
    }
}
        