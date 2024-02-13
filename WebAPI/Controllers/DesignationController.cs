using EnitityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;


namespace WebAPI.Controllers
{
    [Route("/Desgination")]
    [ApiController]
    [Authorize]
    public class DesignationController : ControllerBase
    {
        DesignationRepository service;

        public DesignationController()
        {
            service = new DesignationRepository();
        }
        // GET: api/<DesignationController>
        [HttpGet]
        [Route("")]
        public IEnumerable<Designation> Get()
        {
            return service.GetDesignations();
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]

        public Designation GetById(int id)
        {
            return service.FindById(id);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public void Post([FromBody] Designation value)
        {
            service.Add(value);

        }

        // PUT api/<DesignationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Designation value)
        {
            Designation tomodify = service.FindById(id);
            tomodify.DesignationId = id;
            tomodify.DesignationName = value.DesignationName;
            service.Modify(tomodify);
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}