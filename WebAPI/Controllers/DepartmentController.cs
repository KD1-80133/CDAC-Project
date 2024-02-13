using EntityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        DepartmentRepository service;
        public DepartmentController()
        {
            service = new DepartmentRepository();
        }
        // GET: api/<DepartMentController>
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }*/

        // GET api/<DepartMentController>/5
        [HttpGet("{id}")]
        public Department GetById(int id)
        {

            return service.FindById(id);

        }
        //GET ALL DEPARTMENTS
        [HttpGet]
        [Route("")]
        public IEnumerable<Department> Get()
        {
            return service.GetAllDepartments();

        }


        // POST api/<DepartMentController>
        [HttpPost]
        [Route("Add")]
        public void Post([FromBody] Department value)
        {
            service.Add(value);
        }

        // PUT api/<DepartMentController>/5
        /*[HttpPut]
        [Route("Modify")]
        public void Put([FromBody] Department value)
        {

           service.Modify(value);
       }*/

        [HttpPut]
        [Route("Modify")]
        public void Put(int id, [FromBody] Department value)
        {
            Department tomodified = service.FindById(id);
            Console.WriteLine(tomodified);
            tomodified.DeptId = id;
            tomodified.DeptName = value.DeptName;
            Console.WriteLine(tomodified);
            service.Modify(tomodified);
        }

        // DELETE api/<DepartMentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}
