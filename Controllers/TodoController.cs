using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Entities;
using TodoApp.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.Controllers
{
    [Route("")]
    public class TodoController : Controller
    {
        public TodoRepository TodoRepository { get; set; }

        public TodoController(TodoRepository todoRepository)
        {
            TodoRepository = todoRepository;
        }

        [Route("")]
        public IActionResult Actual()
        {
            if (TodoRepository.ListTodosActual().Count() == 0)
            {
                return RedirectToAction("add");
            }
			return View(TodoRepository.ListTodosActual());
        }

        [HttpGet]
        [Route("archive")]
        public IActionResult Archive()
        {
            if (TodoRepository.ListTodosArchive().Count() == 0)
            {
                return RedirectToAction("Actual");
            }
            return View(TodoRepository.ListTodosArchive());
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(string Title, int isImportant, DateTime dueDate)
        {
            TodoRepository.AddTodo(Title, isImportant, dueDate);
            return RedirectToAction("Actual");
        }

		[HttpPost]
        [Route("/{id}/delete")]
        public IActionResult Delete(int id)
        {
            TodoRepository.DeleteTodo(id);
            return RedirectToAction("Actual");
        }

        [HttpPost]
        [Route("archive/{id}/delete")]
        public IActionResult DeleteFromArchive(int id)
        {
            TodoRepository.DeleteTodo(id);
            return RedirectToAction("Archive");
        }

        [HttpPost]
        [Route("/{id}/archive")]
        public IActionResult Archive(int id)
        {
            TodoRepository.ArchiveTodo(id);
            return RedirectToAction("Actual");
        }


        [HttpPost]
        [Route("/{id}/done")]
        public IActionResult Done(int id)
        {
            TodoRepository.Done(id);
            return RedirectToAction("Actual");
        }
    }
}
