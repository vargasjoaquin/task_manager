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

        public async System.Threading.Tasks.Task<IEnumerable<TaskResponseDto>> GetTasksByStatus(string status)
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

        public async Task<bool> DeleteTask(int taskId)
        {
            if (!await _taskRepository.Exists(taskId))
                return false;

            await _taskRepository.Delete(taskId);
            return true;
        }
    }
}
