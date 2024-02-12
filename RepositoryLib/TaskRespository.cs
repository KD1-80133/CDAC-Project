using EnitityModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = EnitityModelLib.Task;

namespace RepositoryLib
{
    public interface ITaskRepository
    {
        bool Add(Task task);
        IEnumerable<Task> GetAllTasks();
        void Modify(Task task);
        Task FindById(int taskId);
        bool Remove(int taskId);
    }

    public class TaskRepository : ITaskRepository
    {
        private ProjectDbContext db;

        public TaskRepository()
        {
            db = new ProjectDbContext();
        }

        public bool Add(Task task)
        {
            db.Add(task);
            db.SaveChanges();
            return true;
        }

        public Task FindById(int taskId)
        {
            return db.Tasks.Find(taskId);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return db.Tasks.ToList();
        }

        public void Modify(Task task)
        {
            Task toBeModify = db.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);

            if (toBeModify != null)
            {
                toBeModify.UserId = task.UserId;
                toBeModify.ProjectId = task.ProjectId;
                toBeModify.TaskDescription = task.TaskDescription;
                toBeModify.StartDate = task.StartDate;
                toBeModify.EndDate = task.EndDate;
                toBeModify.WorkHours = task.WorkHours;
                toBeModify.Status = task.Status;

                db.SaveChanges();
            }
        }

        public bool Remove(int taskId)
        {
            Task task = FindById(taskId);

            if (task != null)
            {
                db.Remove(task);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
