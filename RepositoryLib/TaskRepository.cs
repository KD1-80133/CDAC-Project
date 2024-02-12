using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks=EntityModelLib.Tasks;

namespace RepositoryLib
{
    public interface ITaskRepository
    {
        bool Add(Tasks task);
        IEnumerable<Tasks> GetAllTasks();
        void Modify(Tasks task);
        Tasks FindById(int taskId);
        bool Remove(int taskId);
    }

    public class TaskRepository : ITaskRepository
    {
        private ProjectDbContext db;

        public TaskRepository()
        {
            db = new ProjectDbContext();
        }

        public bool Add(Tasks task)
        {
            TimeSpan duration = task.EndDate - task.StartDate;
            int workHours = int.Parse((Math.Floor(duration.TotalDays) * 9).ToString());
            task.WorkHours = workHours;

            db.Add(task);
            db.SaveChanges();
            return true;
        }

        public Tasks FindById(int taskId)
        {
            return db.Tasks.Find(taskId);
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return db.Tasks.ToList();
        }

        public void Modify(Tasks task)
        {
            Tasks toBeModify = db.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);

            if (toBeModify != null)
            {
                toBeModify.UserId = task.UserId;
                toBeModify.ProjectId = task.ProjectId;
                toBeModify.TaskDescription = task.TaskDescription;
                toBeModify.StartDate = task.StartDate;
                toBeModify.EndDate = task.EndDate;

                TimeSpan duration = task.EndDate - task.StartDate;
                int workHours = int.Parse((Math.Floor(duration.TotalDays) * 9).ToString());
                task.WorkHours = workHours;

                toBeModify.Status = task.Status;

                db.SaveChanges();
            }
        }

        public bool Remove(int taskId)
        {
            Tasks task = FindById(taskId);

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
