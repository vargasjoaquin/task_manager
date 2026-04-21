using TaskManagerApi.DTOs.Requests;
using TaskManagerApi.DTOs.Responses;

namespace TaskManagerApi.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(int? idEstado);
        Task<TaskResponseDto?> GetTaskByIdAsync(int id);
        Task<TaskResponseDto> CreateTaskAsync(TaskRequestDto taskDto);
        Task<bool> UpdateTaskAsync(int id, TaskRequestDto taskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
