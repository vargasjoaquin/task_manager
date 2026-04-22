using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.DTOs.Requests;
using TaskManagerApi.DTOs.Responses;
using TaskManagerApi.Interfaces;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Endpoint: GET /api/tasks o /api/tasks?status=Pendiente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetTasks([FromQuery] string? status)
        {
            if (string.IsNullOrEmpty(status))
                return await ListAllTasks(); 
            
            return await FilterTasksByStatus(status); 
        }

        /*
         * "Dado que en el protocolo REST y en el framework de .NET las query strings (como ?status=) 
         * no definen una nueva ruta, sino una variante del mismo recurso, utilicé un método despachador. 
         * Este recibe el pedido y delega la ejecución a dos funciones privadas diferentes (ListAllTasks y FilterTasksByStatus) 
         * para mantener el controlador limpio y respetar los requerimientos de la prueba de tener métodos independientes para cada acción."
         */

        private async Task<ActionResult<IEnumerable<TaskResponseDto>>> ListAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        private async Task<ActionResult<IEnumerable<TaskResponseDto>>> FilterTasksByStatus(string status)
        {
            var tasks = await _taskService.GetTasksByStatus(status);
            return Ok(tasks);
        }

        // Endpoint: GET /api/tasks/{taskId}
        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskResponseDto>> GetTaskById(int taskId)
        {
            var task = await _taskService.GetTaskById(taskId);

            if (task == null)
                return NotFound($"La tarea con ID {taskId} no existe.");

            return Ok(task);
        }

        // Endpoint: POST /api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Post([FromBody] TaskRequestDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _taskService.CreateTask(taskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = result.Id }, result);
        }

        // Endpoint: PUT /api/tasks/{taskId}
        [HttpPut("{taskId}")]
        public async Task<IActionResult> Put(int taskId, [FromBody] TaskRequestDto taskDto)
        {
            if (taskDto == null)
                return BadRequest();

            var updated = await _taskService.UpdateTask(taskId, taskDto);

            if (!updated)
                return NotFound($"No se pudo actualizar. La tarea con ID {taskId} no existe.");

            return NoContent();
        }

        // Endpoint: DELETE /api/tasks/{taskId}
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(int taskId)
        {
            var deleted = await _taskService.DeleteTask(taskId);

            if (!deleted)
                return NotFound($"No se pudo eliminar. La tarea con ID {taskId} no existe.");

            return NoContent();
        }
    }
}
