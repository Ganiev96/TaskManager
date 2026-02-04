namespace TaskManager.Interfaces;

using TaskManager.Models;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAll(int page, int pageSize);
    Task<TaskItem?> GetById(int id);
    Task Add(TaskItem task);
    void Remove(TaskItem task);
    Task<bool> ProjectExists(int projectId);
    Task Save();
}
