using FastEndpoints;
using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.TaskItemsEndpoints;
public record CreateTaskItemRequest(string Title, string Description, string Status);
public record CreateTaskItemDto(string Title, string Description, ItemStatus Status);
public class Create(ITaskItemsService service) : Endpoint<CreateTaskItemRequest, TaskItemDto>
{
    private readonly ITaskItemsService _service = service;

    public override void Configure()
    {
        Post("/tasks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateTaskItemRequest req, CancellationToken ct = default)
    {
        if (!Enum.TryParse<ItemStatus>(req.Status, true, out var status))
        {
            // TODO: Log the error
            await Send.ErrorsAsync(400, ct);
            return;
        }
        await _service.CreateTaskItemAsync(new CreateTaskItemDto(req.Title, req.Description, status));
    }
}


