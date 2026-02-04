using TaskManager.Dtos;

namespace TaskManager.Interfaces;

public interface IProjectService
{
    Task<List<ProjectResponseDto>> GetAll();
    Task Create(ProjectCreateDto dto);
}
