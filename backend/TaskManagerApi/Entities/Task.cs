using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApi.Entities
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion {  get; set; }
        [Required]
        public int IdEstado { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [ForeignKey("IdEstado")]
        public virtual TaskStatus Estado { get; set; } = null!;

        [ForeignKey("IdUsuario")]
        public virtual User Usuario { get; set; } = null!;
    }
}
