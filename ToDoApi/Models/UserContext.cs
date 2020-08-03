using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=user.db");
    }
}
