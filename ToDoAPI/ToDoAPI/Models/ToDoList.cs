﻿using Microsoft.AspNetCore.Http.HttpResults;
using ToDoAPI.Models.Exceptions;



namespace ToDoAPI.Models
{
    public class ToDoList
    {
        public List<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();

        public ToDoList() { }

        public List<ToDoTask> GetAllTasks()
        {
            return Tasks;
        }

        public ToDoTask GetById(int id)
        {
            var task = Tasks.Find(x => x.Id == id);

            if (task == null)
            {
                throw new DomainException("Task not found.");
            }
            return task;
        }

        public void AddTask(ToDoTask task)
        {
            if (task == null)
            {
                throw new DomainException("Task cannot be null.");
            }

            Tasks.Add(task);
        }

        public void RemoveTask(ToDoTask task)
        {
            var t = Tasks.Find(x => x.Id == task.Id);


            if (t == null)
            {
                throw new DomainException("Not Found.");
            }

            Tasks.Remove(t);
        }

        public void RemoveAll()
        {
            if (Tasks.Count <= 0)
            {
                throw new DomainException("List is already empty.");
            }
            
            Tasks.Clear();
        }

        public void AddTag(int id, string tag)
        {
            var t = GetById(id);

            t.AddTag(tag);
        }

        public void UpdateTask(int id, string title, string description)
        {
            var task = GetById(id);         
            task.Update(title, description);            
        }
    }
}
