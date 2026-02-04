namespace TaskManager.Interfaces;

using TaskManager.Dtos;

public interface ITaskService
{
    Task<List<TaskResponseDto>> GetAll(int page, int pageSize);
    Task Create(CreateTaskDto dto);
    Task Update(int id, UpdateTaskDto dto);
    Task Delete(int id);
}
