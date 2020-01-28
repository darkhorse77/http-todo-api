using Microsoft.EntityFrameworkCore;
using System;

namespace HTTP_TODO_API.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskList> CustomLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().Property(u => u.Priority).HasDefaultValue(Priority.Medium);
            modelBuilder.Entity<Task>().Property(u => u.Status).HasDefaultValue(Status.Active);
            modelBuilder.Entity<Task>().Property(u => u.Created).HasDefaultValue(DateTime.Now);
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
