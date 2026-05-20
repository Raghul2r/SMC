using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasks();

        Task<TaskItem> GetTaskById(int id);

        Task AddTask(TaskItem task);

        Task UpdateTask(TaskItem task);

        Task DeleteTask(int id);
    }
}