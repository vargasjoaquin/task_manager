using TaskManagerApi.DTOs.Requests;
using TaskManagerApi.DTOs.Responses;
using TaskManagerApi.Interfaces;
using myTaskEntity = TaskManagerApi.Entities.Task;

namespace TaskManagerApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns>Lista de tareas como DTO.</returns>
        public async Task<IEnumerable<TaskResponseDto>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAll();

            return tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id.ToString(),
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                EstadoNombre = t.Estado.Nombre,
                UsuarioNombre = t.Usuario.Nombre,
                FechaCreacion = t.FechaCreacion
            });
        }

        /// <summary>
        /// Obtiene tareas filtradas por estado.
        /// </summary>
        /// <param name="status">Estado de la tarea.</param>
        /// <returns>Lista de tareas como DTO.</returns>
        public async Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(string status)
        {
            var tasks = await _taskRepository.GetByStatus(status);

            return tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id.ToString(),
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                EstadoNombre = t.Estado.Nombre,
                UsuarioNombre = t.Usuario.Nombre,
                FechaCreacion = t.FechaCreacion
            });
        }

        /// <summary>
        /// Obtiene una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns>La tarea como DTO o null si no existe.</returns>
        public async Task<TaskResponseDto?> GetTaskById(int taskId)
        {
            var task = await _taskRepository.GetById(taskId);
            
            if (task == null) 
                return null;

            return new TaskResponseDto
            {
                Id = task.Id.ToString(),
                Titulo = task.Titulo,
                Descripcion = task.Descripcion,
                EstadoNombre = task.Estado.Nombre,
                UsuarioNombre = task.Usuario.Nombre,
                FechaCreacion = task.FechaCreacion
            };
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="taskDto">Datos de la tarea.</param>
        /// <returns>La tarea creada como DTO.</returns>
        public async Task<TaskResponseDto> CreateTask(TaskRequestDto taskDto)
        {
            var newTask = new myTaskEntity
            {
                Titulo = taskDto.Titulo,
                Descripcion = taskDto.Descripcion,
                IdEstado = taskDto.IdEstado,
                IdUsuario = taskDto.IdUsuario,
                FechaCreacion = DateTime.Now
            };

            await _taskRepository.Add(newTask);

            return new TaskResponseDto
            {
                Id = newTask.Id.ToString(),
                Titulo = newTask.Titulo,
                Descripcion = newTask.Descripcion,
                EstadoNombre = "Registrada", 
                UsuarioNombre = "Registrado", 
                FechaCreacion = newTask.FechaCreacion
            };
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <param name="taskDto">Datos actualizados.</param>
        /// <returns>True si la actualización fue exitosa, false si no existe.</returns>
        public async Task<bool> UpdateTask(int taskId, TaskRequestDto taskDto)
        {
            var existingTask = await _taskRepository.GetById(taskId);
            
            if (existingTask == null) 
                return false;

            existingTask.Titulo = taskDto.Titulo;
            existingTask.Descripcion = taskDto.Descripcion;
            existingTask.IdEstado = taskDto.IdEstado;
            existingTask.IdUsuario = taskDto.IdUsuario;

            await _taskRepository.Update(existingTask);
            return true;
        }

        /// <summary>
        /// Elimina una tarea por su id.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <returns>True si la eliminación fue exitosa, false si la tarea no existe.</returns>
        public async Task<bool> DeleteTask(int taskId)
        {
            if (!await _taskRepository.Exists(taskId))
                return false;

            await _taskRepository.Delete(taskId);
            return true;
        }
    }
}
