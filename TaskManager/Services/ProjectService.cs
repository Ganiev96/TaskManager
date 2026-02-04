using AutoMapper;
using TaskManager.Dtos;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repo;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<ProjectResponseDto>> GetAll()
    {
        var projects = await _repo.GetAll();
        return _mapper.Map<List<ProjectResponseDto>>(projects);
    }

    public async Task Create(ProjectCreateDto dto)
    {
        var project = _mapper.Map<Project>(dto);

        await _repo.Add(project);
        await _repo.Save();
    }
}
