using EnitityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/Projects")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        ProjectRepository service;
        public ProjectController()
        {
            service = new ProjectRepository();
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return service.GetAllProjects();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project GetById(int id)
        {
            return service.FindById(id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] Project project)
        {
            service.Add(project);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project project)
        {
            Project tomodify = service.FindById(id);
            tomodify.ProjectId = id;
            tomodify.StartDate = project.StartDate;
            tomodify.EndDate = project.EndDate;
            tomodify.Title = project.Title;
            service.Modify(tomodify);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}