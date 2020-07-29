using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
    public class ToDoItemContext : DbContext
    {
        public DbSet<ToDoItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=todo.db");
    }
}
