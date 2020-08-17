using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDoApi.Models
{
    public class ToDoItemContext : DbContext
    {        
        public DbSet<ToDoItem> Items { get; set; }

        public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base(options)
        {

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
