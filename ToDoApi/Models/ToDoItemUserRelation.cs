using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
    public class ToDoItemToUserRelationContext : DbContext
    {
        public DbSet<ToDoItemToUserRelation> Relations { get; set; }

        public ToDoItemToUserRelationContext()
        { }

        public ToDoItemToUserRelationContext(DbContextOptions<ToDoItemToUserRelationContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Globals.CONNECTIONSTRING);
        }
    }

    public class ToDoItemToUserRelation
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string ToDoItemID { get; set; }

        [Required]
        public string UserID { get; set; }
    }
}
