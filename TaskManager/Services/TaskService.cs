using AutoMapper;
using TaskManager.Dtos;
using TaskManager.Models;
using TaskManager.Interfaces;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<TaskResponseDto>> GetAll(int page, int pageSize)
    {
        var tasks = await _repo.GetAll(page, pageSize);
        return _mapper.Map<List<TaskResponseDto>>(tasks);
    }

    public async Task Create(CreateTaskDto dto)
    {
        if (!await _repo.ProjectExists(dto.ProjectId))
            throw new Exception("Project not found");

        var task = _mapper.Map<TaskItem>(dto);
        task.IsCompleted = false;

        await _repo.Add(task);
        await _repo.Save();
    }

    public async Task Update(int id, UpdateTaskDto dto)
    {
        var task = await _repo.GetById(id);
        if (task == null)
            throw new Exception("Task not found");

        if (!await _repo.ProjectExists(dto.ProjectId))
            throw new Exception("Project not found");

        _mapper.Map(dto, task);
        await _repo.Save();
    }

    public async Task Delete(int id)
    {
        var task = await _repo.GetById(id);
        if (task == null)
            throw new Exception("Task not found");

        _repo.Remove(task);
        await _repo.Save();
    }
}
