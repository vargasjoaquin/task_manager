using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApi.Entities
{
    [Table("TaskStatus")]
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
