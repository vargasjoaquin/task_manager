using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApi.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
