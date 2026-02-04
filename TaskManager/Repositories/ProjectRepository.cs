using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TaskDbContext _context;

    public ProjectRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAll()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task Add(Project project)
    {
        await _context.Projects.AddAsync(project);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
