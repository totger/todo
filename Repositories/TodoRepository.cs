using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Entities;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository
    {
        TodoContext todoContext;

        public TodoRepository(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }

        public IOrderedEnumerable<Todo> ListTodosActual()
        {
            var currentList = todoContext.TodoDb.Where(t => !t.IsArchive).ToList();
            currentList.ForEach(t => t.UpdateDaysRemaining());
            return currentList.OrderBy(t => t.DaysRemaining);
        }

        public List<Todo> ListTodosArchive()
        {
            return todoContext.TodoDb.Where(t => t.IsArchive).ToList();
        }

        public void AddTodo(string newTitle, int isImportant, DateTime dueDate)
        {

            var newTodo = new Todo
            {
                Title = newTitle,
                IsImportant = (isImportant == 1),
                DueDate = dueDate
            };

            todoContext.TodoDb.Add(newTodo);
            todoContext.SaveChanges();
        }

        public void DeleteTodo(int id)
        {
            Todo todoToDelete = todoContext.TodoDb.FirstOrDefault(x => x.Id == id);
            todoContext.TodoDb.Remove(todoToDelete);
            todoContext.SaveChanges();
        }

        public void Done(int id)
        {
            Todo doneTodo = todoContext.TodoDb.FirstOrDefault(x => x.Id == id);
            doneTodo.IsDone = !doneTodo.IsDone;
            todoContext.SaveChanges();
        }

        public void ArchiveTodo(int id)
        {
            Todo todoToArchive = todoContext.TodoDb.FirstOrDefault(x => x.Id == id);
            todoToArchive.IsArchive = true;
            todoContext.SaveChanges();
        }
    }
}
