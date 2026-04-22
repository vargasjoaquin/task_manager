namespace TaskManagerApi.Interfaces
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Entities.Task>> GetAll();

        /// <summary>
        /// Obtiene las tareas filtradas por estado.
        /// </summary>
        /// <param name="status">Estado de la tarea (ej: Pendiente, En progreso, Completada).</param>
        /// <returns></returns>
        Task<IEnumerable<Entities.Task>> GetByStatus(string status);

        /// <summary>
        /// Obtiene una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns></returns>
        Task<Entities.Task?> GetById(int taskId);

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="task">Datos de la tarea a crear.</param>
        /// <returns></returns>
        Task Add(Entities.Task task);

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="task">Entidad de tarea con los datos actualizados.</param>
        /// <returns></returns>
        Task Update(Entities.Task task);

        /// <summary>
        /// Elimina una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea a eliminar</param>
        /// <returns></returns>
        Task Delete(int taskId);

        /// <summary>
        /// Verifica si una tarea existe.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns></returns>
        Task<bool> Exists(int taskId);
    }
}
