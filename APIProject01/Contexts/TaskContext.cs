using Microsoft.EntityFrameworkCore;
using APIProject01.Model;

namespace APIProject01.Contexts
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }
        public DbSet<TaskItem> Tasks { get; set; } = null;
    }
}
