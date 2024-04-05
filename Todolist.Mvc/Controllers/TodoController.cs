using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todolist.Mvc.Models;
using Todolist.Mvc.Services.Interfaces;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoDto todoDto)
        {
            if (ModelState.IsValid)
            {
                await _todoService.CreateTodoAsync(todoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(todoDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoDto = await _todoService.GetTodoByIdAsync(id.Value);
            if (todoDto == null)
            {
                return NotFound();
            }
            return View(todoDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoDto todoDto)
        {
            if (id != todoDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _todoService.UpdateTodoAsync(id, todoDto);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todoDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}