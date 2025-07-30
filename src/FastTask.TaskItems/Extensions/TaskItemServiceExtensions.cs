using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


namespace FastTask.TaskItems.Extensions;

public static class TaskItemServiceExtensions
{
    public static IServiceCollection AddTaskItemService(this IServiceCollection services, ConfigurationManager config, ILogger logger)
    {
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();

        logger.Information("{Module} service has been registered successfully", "TaskItems");
        return services;
    }
}
