using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.Data;
using FastTask.TaskItems.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


namespace FastTask.TaskItems.Extensions;

public static class TaskItemsServiceExtensions
{
    public static IServiceCollection AddTaskItemsService(this IServiceCollection services, ConfigurationManager config, ILogger logger)
    {
        string? connectionString = config.GetConnectionString("TaskItems");
        services.AddDbContext<TaskItemsDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<ITaskItemsRepository, TaskItemsRepository>();
        services.AddScoped<ITaskItemsService, TaskItemsService>();

        logger.Information("{Module} service has been registered successfully", "TaskItems");
        return services;
    }
}
