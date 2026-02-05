namespace TaskManager.Interfaces;

using TaskManager.Dtos;

public interface ITaskService
{
    Task<List<TaskResponseDto>> GetAll(int userId, int page, int pageSize);
    Task Create(int userId, CreateTaskDto dto);
    Task Update(int userId, int id, UpdateTaskDto dto);
    Task Delete(int userId, int id);
}
