namespace TaskManagerApi.DTOs.Responses
{
    public class TaskResponseDto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
