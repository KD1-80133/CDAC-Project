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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DepartMentController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/
        [HttpGet]
        [Route("ById")]
        public Department Get(int id)
        {
            return service.FindById(id);
        }

        // POST api/<DepartMentController>
        [HttpPost]
        [Route("Add")]
        public void Post([FromBody] Department value)
        {
            service.Add(value);
        }

        // PUT api/<DepartMentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<DepartMentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
