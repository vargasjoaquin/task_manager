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

        /// <summary>
        /// Obtiene todas las tareas incluyendo su estado y usuario asociado.
        /// </summary>
        /// <returns>Lista de tareas.</returns>
        public async Task<IEnumerable<myTaskEntity>> GetAll()
        {
            return await _apiContext.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Usuario)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene tareas filtradas por estado.
        /// </summary>
        /// <param name="status">Nombre del estado de la tarea.</param>
        /// <returns>Lista de tareas que coinciden con el estado indicado.</returns>

        public async Task<IEnumerable<myTaskEntity>> GetByStatus(string status)
        {
            return await _apiContext.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Usuario)
                .Where(t => t.Estado.Nombre.ToLower() == status.ToLower())
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns>La tarea encontrada.</returns>
        public async Task<myTaskEntity?> GetById(int taskId)
        {
            return await _apiContext.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == taskId);
        }

        /// <summary>
        /// Crea una nueva tarea a la base de datos.
        /// </summary>
        /// <param name="task">Entidad de tarea a crear.</param>
        public async Task Add(myTaskEntity task)
        {
            await _apiContext.Tareas.AddAsync(task);
            await _apiContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="task">Entidad de tarea con los datos actualizados.</param>
        public async Task Update(myTaskEntity task)
        {
            _apiContext.Tareas.Update(task);
            await _apiContext.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica si existe una tarea con el id especificado.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns>True si existe, false en caso contrario.</returns>
        public async Task<bool> Exists(int taskId)
        {
            return await _apiContext.Tareas.AnyAsync(t => t.Id == taskId);
        }

        /// <summary>
        /// Elimina una tarea por su identificador.
        /// </summary>
        /// <param name="taskId">ID de la tarea a eliminar.</param>
        public async Task Delete(int taskId)
        {
            var task = await GetById(taskId);

            if (task != null)
                _apiContext.Tareas.Remove(task);
                await _apiContext.SaveChangesAsync();
        }
    }
}
