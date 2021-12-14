using MVVM1.Models;
using MVVM1.Models.Context;
using System;
using System.Collections.Generic;

namespace MVVM1.Infrastructure.Stores
{
    public class TaskStore
    {
        private readonly List<Task> _tasks;

        public IEnumerable<Task> Tasks => _tasks;

        public event Action<Task> TaskAdded;

        public event Action<Task> TaskDeleted;

        public TaskStore()
        {
            _tasks = new List<Task>();
        }

        public void Load()
        {
            _tasks.Clear();
            using (КурсоваяContext db = new())
            {
                _tasks.AddRange(db.Tasks);

                foreach (Task task in _tasks)
                {
                    task.Emp = db.Emps.Find(task.EmpId);
                    foreach (Report report in db.Reports)
                        if (report.TaskId == task.Id)
                            task.Reports.Add(report);
                }
            }
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);

            using (КурсоваяContext db = new())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }

            OnTaskAdded(task);
        }

        private void OnTaskAdded(Task task)
        {
            TaskAdded?.Invoke(task);
        }

        public void DelTask(Task task)
        {
            _tasks.Remove(task);

            using (КурсоваяContext db = new())
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }

            OnTaskDeleted(task);
        }

        private void OnTaskDeleted(Task task)
        {
            TaskDeleted?.Invoke(task);
        }
    }
}
