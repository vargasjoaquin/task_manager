namespace TaskManagerApi.DTOs.Requests
{
    public class TaskRequestDto
    {
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
    }
}
