using EnitityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model.EMPDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/Employee")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository service;
        public EmployeeController()
        {
            service = new EmployeeRepository();
        }
        // GET: api/<EmployeeController>
        /*[HttpGet]
         public IEnumerable<Employee> Get()
         {
             return service.GetAllEmployees();
         }*/


        [HttpGet]
        public IEnumerable<EmpDTO> Get()
        {
            //return service.GetAllEmployees();
            List<EmpDTO> empDTOList = new List<EmpDTO>();
            foreach (Employee emp in service.GetAllEmployees())
            {
                EmpDTO edl = new EmpDTO();
                edl.EmpId = emp.EmpId;
                edl.DeptId = emp.DeptId;
                edl.DesignationId = emp.DesignationId;
                edl.FirstName = emp.FirstName;
                edl.LastName = emp.LastName;
                edl.HireDate = emp.HireDate;
                edl.HourlyRate = emp.HourlyRate;
                edl.IsResigned = emp.IsResigned;
                edl.ManagerId = emp.ManagerId;
                edl.UserId = emp.UserId;
                empDTOList.Add(edl);


            }
            return empDTOList;
        }

        // GET api/<EmployeeController>/5
        /*        [HttpGet("{id}")]
                public Employee GetById(int id)
                {
                    return service.FindById(id);
                }*/

        [HttpGet("{id}")]
        public EmpDTO GetById(int id)
        {
            Employee emp = service.FindById(id);
            EmpDTO empdto = new EmpDTO();
            empdto.EmpId = emp.EmpId;
            empdto.DeptId = emp.DeptId;
            empdto.DesignationId = emp.DesignationId;
            empdto.FirstName = emp.FirstName;
            empdto.LastName = emp.LastName;
            empdto.HourlyRate = emp.HourlyRate;
            empdto.IsResigned = emp.IsResigned;
            empdto.ManagerId = emp.ManagerId;
            empdto.HireDate = emp.HireDate;
            empdto.UserId = emp.UserId;
            return empdto;
        }

        // POST api/<EmployeeController>
        /* [HttpPost]
         public void Post([FromBody] Employee emp)
         {
             service.Add(emp);
         }*/

        [HttpPost]
        public void Post([FromBody] AddEmpDTO empdto)
        {
            Employee emp = new Employee();

            emp.DeptId = empdto.DeptId;
            emp.DesignationId = empdto.DesignationId;
            emp.FirstName = empdto.FirstName;
            emp.LastName = empdto.LastName;
            emp.HourlyRate = empdto.HourlyRate;
            emp.IsResigned = empdto.IsResigned;
            emp.ManagerId = empdto.ManagerId;
            emp.HireDate = empdto.HireDate;
            emp.UserId = emp.UserId;
            service.Add(emp);
        }

        // PUT api/<EmployeeController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            Employee tomodify=service.FindById(id);
            tomodify.EmpId = id;
            tomodify.FirstName = value.FirstName;
            tomodify.LastName = value.LastName;
            tomodify.HourlyRate = value.HourlyRate;
            tomodify.IsResigned = value.IsResigned;
            tomodify.ManagerId = value.ManagerId;
            tomodify.DesignationId = value.DesignationId;
            service.Modify(tomodify);
        }*/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ModifyEmpDTO empdto)
        {
            Employee tomodify = service.FindById(id);
            tomodify.EmpId = id;
            tomodify.FirstName = empdto.FirstName;
            tomodify.LastName = empdto.LastName;
            tomodify.HourlyRate = empdto.HourlyRate;
            tomodify.IsResigned = empdto.IsResigned;
            tomodify.ManagerId = empdto.ManagerId;
            tomodify.DeptId = empdto.DeptId;
            tomodify.DesignationId = empdto.DesignationId;
            tomodify.IsResigned = empdto.IsResigned;
            tomodify.UserId = empdto.UserId;
            service.Modify(tomodify);
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}