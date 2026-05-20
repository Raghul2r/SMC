using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // READ
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasks();

            return View(tasks);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                await _taskService.AddTask(task);

                return RedirectToAction("Index");
            }

            return View(task);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskById(id);

            return View(task);
        }

        // EDIT POST
        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                await _taskService.UpdateTask(task);

                return RedirectToAction("Index");
            }

            return View(task);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetTaskById(id);

            return View(task);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taskService.DeleteTask(id);

            return RedirectToAction("Index");
        }
    }
}