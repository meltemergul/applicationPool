using System;
using applicationPool.Repositories;
using Microsoft.AspNetCore.Mvc;
using applicationPool.Models;
using applicationPool.Data;

namespace applicationPool.Controllers
{
	public class TodoController : Controller
	{
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {
            var todoItems = _todoRepository.GetAll();
            return View(todoItems);
        }

        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _todoRepository.Add(todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        public IActionResult Edit(int id)
        {
            var todoItem = _todoRepository.GetById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _todoRepository.Update(todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        public IActionResult Delete(int id)
        {
            var todoItem = _todoRepository.GetById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _todoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

