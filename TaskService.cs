using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ ALL
        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // READ BY ID
        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        // CREATE
        public async Task AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);

            await _context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);

            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);

                await _context.SaveChangesAsync();
            }
        }
    }
}