using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {

        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var todos = _repository.GetAll();

            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ToDoItem todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
            {
                ModelState.AddModelError("Title", "Title is required");
            }

            if (ModelState.IsValid)
            {
                _repository.Add(todo);
                TempData["SuccessMessage"] = "Todo item created successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(todo);



        }

        public IActionResult Edit(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(ToDoItem todo)
        {
            if (String.IsNullOrWhiteSpace(todo.Title))
            {
                ModelState.AddModelError("Title", "Titie is required");
            }
            if (ModelState.IsValid)
            {
                _repository.Add(todo);
                TempData["SuccessMessage"] = "Todo item created successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(todo);
        }

        public IActionResult Delete(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            TempData["SuccessMessage"] = "Todo item deleted successfully!";
            return RedirectToAction(nameof(Index));

        }

    }
}
