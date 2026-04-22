using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Entities;
using myTask = TaskManagerApi.Entities.Task;
using myTaskStatus = TaskManagerApi.Entities.TaskStatus;

namespace TaskManagerApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<myTaskStatus> EstadosTareas { get; set; }
        public DbSet<myTask> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
