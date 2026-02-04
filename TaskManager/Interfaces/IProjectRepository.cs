using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAll();
    Task Add(Project project);
    Task Save();
}
