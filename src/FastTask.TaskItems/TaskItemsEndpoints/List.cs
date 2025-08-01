using FastEndpoints;
using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.DTOs;

namespace FastTask.TaskItems.TaskItemsEndpoints;

public record ListTaskItemsResponse(IReadOnlyList<TaskItemDto> TaskList);
public class List(ITaskItemsService taskService) : EndpointWithoutRequest<ListTaskItemsResponse>
{
    private readonly ITaskItemsService _taskService = taskService;

    public override void Configure()
    {
        Get("/tasks");
        Description(builder =>
            builder.ProducesProblemDetails(400, "application/json+problem")
                   .ProducesProblemDetails(500, "application/json+problems")
            );
        AllowAnonymous();
    }

    public override async Task HandleAsync(
       CancellationToken cancellationToken = default)
    {
        var taskList = await _taskService.ListTaskItemsAsync();

        await Send.OkAsync(new ListTaskItemsResponse(taskList));
    }
}
