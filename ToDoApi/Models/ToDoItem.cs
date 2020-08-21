using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
    public class ToDoItemContext : DbContext
    {        
        public DbSet<ToDoItem> Items { get; set; }

        public ToDoItemContext()
        { }

        public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Globals.CONNECTIONSTRING);
        }
    }

    public class ToDoItem
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Notes { get; set; }

        public bool Done { get; set; }
    }
}
