using TaskManagerApi.DTOs.Requests;
using TaskManagerApi.DTOs.Responses;

namespace TaskManagerApi.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseDto>> GetAllTasks();
        Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(string status);
        Task<TaskResponseDto?> GetTaskById(int taskId);
        Task<TaskResponseDto> CreateTask(TaskRequestDto taskDto);
        Task<bool> UpdateTask(int taskId, TaskRequestDto taskDto);
        Task<bool> DeleteTask(int taskId);
    }
}
