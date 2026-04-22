namespace TaskManagerApi.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAll();
        Task<IEnumerable<Entities.Task>> GetByStatus(string status);
        Task<Entities.Task?> GetById(int taskId);
        Task Add(Entities.Task task);
        Task Update(Entities.Task task);
        Task Delete(int taskId);
        Task<bool> Exists(int taskId);
    }
}
