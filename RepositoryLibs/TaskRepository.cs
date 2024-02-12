﻿using EntityModelLib;
using Task = EntityModelLib.Task;

namespace RepositoryLib
{
    public interface ITaskRepository
    {
        bool Add(EntityModelLib.Task task);
        IEnumerable<EntityModelLib.Task> GetAllTasks();
        void Modify(EntityModelLib.Task task);
        Task FindById(int taskId);
        bool Remove(int taskId);
    }

    public class TaskRepository : ITaskRepository
    {
        private ProjectContext db;

        public TaskRepository()
        {
            db = new ProjectContext();
        }

        public bool Add(Task task)
        {
            TimeSpan duration = task.EndDate - task.StartDate;
            int workHours = int.Parse((Math.Floor(duration.TotalDays) * 9).ToString());
            task.WorkHours = workHours;

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

                TimeSpan duration = task.EndDate - task.StartDate;
                int workHours = int.Parse((Math.Floor(duration.TotalDays) * 9).ToString());
                toBeModify.WorkHours = workHours;

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

