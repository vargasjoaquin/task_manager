using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data;
using TaskManagerApi.Interfaces;
using myTaskEntity = TaskManagerApi.Entities.Task;

namespace TaskManagerApi.Repositories
{
    public class TaskRespository : ITaskRepository
    {
        private readonly ApiDbContext _apiContext;

        public TaskRespository(ApiDbContext context)
        {
            _apiContext = context;
        }

        public async Task<IEnumerable<myTaskEntity>> GetAll()
        {
            return await _apiContext.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Usuario)
                .ToListAsync();
        }


        public async Task<IEnumerable<TaskManagerApi.Entities.Task>> GetByStatus(string status)
        {
            return await _apiContext.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Usuario)
                .Where(t => t.Estado.Nombre.ToLower() == status.ToLower())
                .ToListAsync();
        }

        public async Task<myTaskEntity?> GetById(int taskId)
        {
            return await _apiContext.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == taskId);
        }

        public async Task Add(myTaskEntity task)
        {
            await _apiContext.Tareas.AddAsync(task);
            await _apiContext.SaveChangesAsync();
        }
        public async Task Update(myTaskEntity task)
        {
            _apiContext.Tareas.Update(task);
            await _apiContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int taskId)
        {
            return await _apiContext.Tareas.AnyAsync(t => t.Id == taskId);
        }

        public async Task Delete(int taskId)
        {
            var task = await GetById(taskId);

            if (task != null)
                _apiContext.Tareas.Remove(task);
                await _apiContext.SaveChangesAsync();
        }
    }
}
