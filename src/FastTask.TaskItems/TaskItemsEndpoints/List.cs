using FastEndpoints;
using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.TaskItemsEndpoints;
public class ListTaskItemsByStatusRequest
{
    [QueryParam]
    public string? Status { get; init; }
}
public record ListTaskItemsResponse(IReadOnlyList<TaskItemDto> TaskList);
public class List(ITaskItemsService service) : Endpoint<ListTaskItemsByStatusRequest,ListTaskItemsResponse>
{
    private readonly ITaskItemsService _service = service;

    public override void Configure()
    {
        Get("/tasks");
        Description(builder =>
            builder.ProducesProblemDetails(400, "application/json+problem")
                   .ProducesProblemDetails(500, "application/json+problems")
            );
        AllowAnonymous();
    }

    public override async Task HandleAsync(ListTaskItemsByStatusRequest req,
       CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrEmpty(req.Status))
        {
            if (!Enum.TryParse<ItemStatus>(req.Status, true, out var status))
            {
                // TODO: Log the error
                // TODO: Return a proper error response.
                return;
            }
            var taskList = await _service.ListTaskItemsByStatusAsync(status);
            await Send.OkAsync(new ListTaskItemsResponse(taskList), cancellationToken);
        }
        else
        {
            var taskList = await _service.ListTaskItemsAsync();

            await Send.OkAsync(new ListTaskItemsResponse(taskList), cancellationToken);
        }
         
    }
}
