using EntityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model.TASKDTO;
using Task = EntityModelLib.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/Task")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        TaskRepository service;
        public TaskController()
        {
            service = new TaskRepository();
        }
        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<TaskDTO> Get()
        {
            List<TaskDTO> taskDTOList = new List<TaskDTO>();
            foreach (Task task in service.GetAllTasks())
            {
                TaskDTO tdl = new TaskDTO();
                tdl.TaskId = task.TaskId;
                tdl.Status = task.Status;
                tdl.ProjectId = task.ProjectId;
                tdl.StartDate = task.StartDate;
                tdl.EndDate = task.EndDate;
                tdl.TaskId = task.TaskId;
                tdl.WorkHours = task.WorkHours;
                tdl.UserId = task.UserId;
                tdl.TaskDescription = task.TaskDescription;
                taskDTOList.Add(tdl);
            }
            return taskDTOList;


        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public TaskDTO Get(int id)
        {
            Task task = service.FindById(id);
            TaskDTO taskdto = new TaskDTO();
            taskdto.TaskId = task.TaskId;
            taskdto.Status = task.Status;
            taskdto.ProjectId = task.ProjectId;
            taskdto.StartDate = task.StartDate;
            taskdto.EndDate = task.EndDate;
            taskdto.TaskId = task.TaskId;
            taskdto.WorkHours = task.WorkHours;
            taskdto.UserId = task.UserId;
            taskdto.TaskDescription = task.TaskDescription;
            return taskdto;
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] AddTaskDTO tasks)
        {
            Task taskToAdd = new Task();
            taskToAdd.ProjectId = tasks.ProjectId;
            taskToAdd.StartDate = tasks.StartDate;
            taskToAdd.EndDate = tasks.EndDate;
            taskToAdd.UserId = tasks.UserId;
            taskToAdd.TaskDescription = tasks.TaskDescription;
            taskToAdd.Status = tasks.Status;
            service.Add(taskToAdd);


        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ModifyTaskDTO tasks)
        {
            Task tomodify = service.FindById(id);
            tomodify.TaskId = id;
            tomodify.ProjectId = tasks.ProjectId;
            tomodify.StartDate = tasks.StartDate;
            tomodify.EndDate = tasks.EndDate;
            tomodify.UserId = tasks.UserId;
            tomodify.TaskDescription = tasks.TaskDescription;
            tomodify.Status = tasks.Status;
            service.Modify(tomodify);

        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}
