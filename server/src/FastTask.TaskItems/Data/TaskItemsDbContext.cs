using FastTask.TaskItems.Entities;
using Microsoft.EntityFrameworkCore;
using Namotion.Reflection;
using System.Reflection;

namespace FastTask.TaskItems.Data;

public class TaskItemsDbContext : DbContext
{
    internal DbSet<TaskItem> TaskItems { get; set; }

    public TaskItemsDbContext(DbContextOptions<TaskItemsDbContext> options) : base(options)
    {
       
    }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TaskItems");
        // Allow for separate config files per Assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
