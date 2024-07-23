using Microsoft.EntityFrameworkCore;
using applicationPool.Models; 

namespace applicationPool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
        {
        }

        public DbSet<TodoItem> ToDoItems { get; set; }

        public DbSet<User> Users { get; set; }
    }
}