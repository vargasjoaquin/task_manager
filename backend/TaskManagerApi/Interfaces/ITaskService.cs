using TaskManagerApi.DTOs.Requests;
using TaskManagerApi.DTOs.Responses;

namespace TaskManagerApi.Interfaces
{
    public interface ITaskService
    {
        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TaskResponseDto>> GetAllTasks();

        /// <summary>
        /// Obtiene las tareas filtradas por estado.
        /// </summary>
        /// <param name="status">Estado de la tarea (ej: Pendiente, En progreso, Completada).</param>
        /// <returns></returns>
        Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(string status);

        /// <summary>
        /// Obtiene una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns></returns>
        Task<TaskResponseDto?> GetTaskById(int taskId);

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="taskDto">Datos de la tarea a crear.</param>
        /// <returns></returns>
        Task<TaskResponseDto> CreateTask(TaskRequestDto taskDto);

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="taskId">ID de la tarea a actualizar.</param>
        /// <param name="taskDto">Nuevos datos de la tarea.</param>
        /// <returns></returns>
        Task<bool> UpdateTask(int taskId, TaskRequestDto taskDto);

        /// <summary>
        /// Elimina una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea a eliminar.</param>
        /// <returns></returns>
        Task<bool> DeleteTask(int taskId);
    }
}
