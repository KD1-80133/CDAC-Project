using EntityModelLib;
using EntityModelsLib;
using Project_logger;
using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = EntityModelLib.Task;



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
            //Department department = new Department() { DeptName = "Design" };
            //dept.Add(department);
            //dept.Modify(new Department() { DeptId = 2, DeptName = "HR123" });
            //dept.Remove(1);
            //IEnumerable<Department> deptList = dept.GetAllDepartments();
            //foreach (var item in deptList)
            //{
            //    Console.WriteLine(item);

            //}

            //IDesignationRepository desgn = new DesignationRepository();
            //Designation designation = new Designation() { DesignationName = "Data Scientist" };
            //desgn.Add(designation);
            //desgn.Modify(new Designation { DesignationId = 1, DesignationName = "Team Head" });
            //desgn.Remove(2);
            //IEnumerable<Designation> desnList = desgn.GetAllDesignations();
            //foreach (var item in desnList)
            //{
            //    Console.WriteLine(item);

            //}

            IEmployeeRepository emp = new EmployeeRepository();
            Employee employee = new Employee() { FirstName = "shital", LastName = "chougule", DesignationId = 3, HireDate = DateTime.Now, IsResigned = false, HourlyRate = 500, DepartmentId = 2, ManagerId = 2 };
            emp.Add(employee);

            //emp.Modify(new Employee() { FirstName = "Nivedita", LastName = "chougule", DesignationId = 2,IsResigned = true });

            //IProjectRepository proj = new ProjectRepository();
            //Project project = new Project() { Title = "Matrimonal mgt. system" ,StartDate=new DateTime(2024,10,15) ,EndDate=new DateTime(2024,12,10)};
            //proj.Add(project);

            //proj.Modify(new Project() { ProjectId=1, Title = "ETiffin mgt. system", StartDate = new DateTime(2024, 10, 15), EndDate = new DateTime(2024, 11, 10) });
            //Project project = new Project() { Title = "Educational mgt. system", StartDate = new DateTime(2024, 02, 22), EndDate = new DateTime(2024, 03, 05) };
            //proj.Add(project);
            //proj.Remove(2);
            //Project project = new Project() { Title = "Educational mgt. system", StartDate = new DateTime(2024, 02, 22), EndDate = new DateTime(2024, 03, 05) };
            //proj.Add(project);
            //IEnumerable<Project> projList = proj.GetAllProjects();
            //foreach (var item in projList)
            //{
            //    Console.WriteLine(item);

            //}

            //IProjectMembersRepository projmem = new ProjectMembersRepository();
            //ProjectMembers members = new ProjectMembers() { UserId=1,ProjectId=3};
            //projmem.Add(members);
            //ProjectMembers members = new ProjectMembers() { UserId = 2, ProjectId = 1};
            //projmem.Add(members);
            //projmem.Remove(3);
            //IEnumerable<ProjectMembers> projMemList = projmem.GetAllProjectMembers();
            //foreach (var item in projMemList)
            //{
            //    Console.WriteLine(item);

            //}


            //ITaskRepository task = new TaskRepository();
            //Task newTask = new Task() { };


            //IBankAccountRepository bankAccount = new BankAccountRepository();
            //BankAccount baccount = new BankAccount() { AccountNo = 123456789, AccountHolderName = "Nivedita patil", AccountType = "Saving", BankName = "SBI", IFSCCode = 456987, UserId = 4 };
            //bankAccount.Add(baccount);
            //BankAccount baccount = new BankAccount() { AccountNo = 987654321, AccountHolderName = "Nivedita Chougule", AccountType = "Current", BankName = "BOI", IFSCCode = 123654, UserId = 3 };
            //bankAccount.Add(baccount);

            // bankAccount.Remove(987654321);
            //bankAccount.Modify(new BankAccount() { AccountNo = 123456789, AccountHolderName = "Nivedita patil", AccountType = "Current", BankName = "BOB", IFSCCode = 456987, UserId = 5 });
            //BankAccount baccount = new BankAccount() { AccountNo = 987654321, AccountHolderName = "Nivedita Chougule", AccountType = "Current", BankName = "BOI", IFSCCode = 123654, UserId = 3 };
            //bankAccount.Add(baccount);
            //IEnumerable<BankAccount> accountList = bankAccount.GetAllAccount();
            //foreach (var item in accountList)
            //{
            //    Console.WriteLine(item);

            //}

            ITaskRepository task = new TaskRepository();
            //Task tk = new Task() { UserId=1,TaskDescription="This is web based application which provide online Tiffin services",StartDate=new DateTime(2024,2,21),EndDate=new DateTime(2024,03,05),Status="In Progress",ProjectId=1};
            //task.Add(tk);
            //Task tk = new Task() { UserId = 2, TaskDescription = "This is web based application which provide online Educational facilities", StartDate = new DateTime(2024, 2, 2), EndDate = new DateTime(2024, 02, 22), Status = "completed", ProjectId = 3 };
            //task.Add(tk);

            //task.Remove(2);
            task.Modify(new Task() { TaskId = 4 ,UserId = 3, TaskDescription = "This is web based application which serves Educational facilities", StartDate = new DateTime(2024, 2, 3), EndDate = new DateTime(2024, 02, 20), Status = "in progress", ProjectId = 3 }); ;






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
