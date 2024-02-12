using EnitityModelLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository service;
        public EmployeeController()
        {
            service = new EmployeeRepository();
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return service.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            return service.FindById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            service.Add(emp);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            Employee tomodify = service.FindById(id);
            tomodify.EmpId = id;
            tomodify.FirstName = value.FirstName;
            tomodify.LastName = value.LastName;
            tomodify.HourlyRate = value.HourlyRate;
            tomodify.IsResigned = value.IsResigned;
            tomodify.ManagerId = value.ManagerId;
            tomodify.DesignationId = value.DesignationId;
            service.Modify(tomodify);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}