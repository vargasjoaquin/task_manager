using TaskManagerApi.Entities;
using myTask = TaskManagerApi.Entities.Task;

namespace TaskManagerApi.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<myTask>> GetAllAsync(int? idEstado); 
        Task<myTask?> GetByIdAsync(int id);
        Task AddAsync(myTask tarea);
        Task UpdateAsync(myTask tarea);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
