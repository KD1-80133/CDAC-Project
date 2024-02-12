using EntityModelLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
          TaskRepository  service;
        public TasksController()
        {
            service = new TaskRepository();
        }
        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            return service.GetAllTasks();
            
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Tasks Get(int id)
        {
            return service.FindById(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] Tasks tasks )
        {
             service.Add(tasks);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tasks tasks)
        {
           Tasks tomodify =service.FindById(id);

        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
