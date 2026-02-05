namespace TaskManager.Interfaces;

using TaskManager.Models;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAll(int userId, int page, int pageSize);
    Task<TaskItem?> GetById(int userId, int id);
    Task Add(TaskItem task);
    void Remove(TaskItem task);
    Task<bool> ProjectExists(int projectId);
    Task Save();
}
