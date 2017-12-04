using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Entities
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<Todo> TodoDb { get; set; }
    }
}
