using EntityModelLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;


namespace WebAPI.Controllers
{
    [Route("/Department")]
    [ApiController]
    public class DepartMentController : ControllerBase
    {
        DepartmentRepository service;
        public DepartMentController()
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
         public Department Get(int id)
         {
             
           return service.FindById(id);

         }
        //GET ALL DEPARTMENTS
        [HttpGet]
        [Route(" ")]
        public IEnumerable<Department> GetDeptList()
        {
            IEnumerable<Department> dept = service.GetDepartments();
            return dept;
        }
       

        // POST api/<DepartMentController>
        [HttpPost]
        [Route("Add")]
        public void Post([FromBody] Department value)
        {
            service.Add(value);
        }

        // PUT api/<DepartMentController>/5
         [HttpPut]
         [Route("Modify")]
         public void Put([FromBody] Department value)
         {
            
            service.Modify(value);
        }

        /*[HttpPut("{id}")]
        [Route("Modify")]
        public void Put(int id, [FromBody] Department value)
        {
            service.FindById(id);
            service.Modify(value);
        }*/

        // DELETE api/<DepartMentController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
            service.Delete(id);
         }


        /*[HttpDelete]
         public void Delete(Department department)
        {
            service.Remove(department);
        }*/

    }
}
