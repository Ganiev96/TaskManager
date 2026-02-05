using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAll(int userId, int page, int pageSize)
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .Include(t=>t.User)
            .Where(t => t.UserId == userId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetById(int id, int userId)
    {
        return await _context.Tasks
            .Include (t => t.Project)
            .Include(t => t.User)
            .FirstOrDefaultAsync(t=> t.Id == id && t.UserId == userId);
    }

    public async Task Add(TaskItem task)
    {
        await _context.Tasks.AddAsync(task);
    }

    public void Remove(TaskItem task)
    {
        _context.Tasks.Remove(task);
    }

    public async Task<bool> ProjectExists(int projectId)
    {
        return await _context.Projects.AnyAsync(x => x.Id == projectId);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
