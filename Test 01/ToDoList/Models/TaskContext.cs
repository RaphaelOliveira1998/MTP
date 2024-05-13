using Microsoft.EntityFrameworkCore;
using T = ToDoList.Models.Task;

namespace ToDoList.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<T> Tasks { get; set; }
    }
}