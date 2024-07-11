using Microsoft.EntityFrameworkCore;
using applicationPool.Models; // TodoItem sınıfının namespace'i

namespace applicationPool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; } // DbSet olarak TodoItem sınıfı kullanılıyor
    }
}
