using System.Text.Json.Serialization;
using FastEndpoints;
using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.TaskItemsEndpoints;

public class UpdateTaskItemStatusRequest
{
    public Guid ItemId { get; set; }
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}

public class UpdateTaskItemStatus(ITaskItemsService service) : Endpoint<UpdateTaskItemStatusRequest, TaskItemDto>
{
    private readonly ITaskItemsService _service = service;

    public override void Configure()
    {
        Put("/tasks/{itemid:guid}");
        AllowAnonymous();

        Description(builder =>
            builder
                   .ProducesProblemDetails(400, "application/json+problem")
                   .ProducesProblemDetails(404, "application/json+problem")
                   .ProducesProblemDetails(500, "application/json+problem")
            );
    }

    public override async Task HandleAsync(UpdateTaskItemStatusRequest req,
       CancellationToken ct = default)
    {
        
            if (!Enum.TryParse<ItemStatus>(req.Status, true, out var status))
            {
                // TODO: Log the error
                await Send.ErrorsAsync(400, ct);
                return;
            }
            var updatedTaskItem = await _service.UpdateTaskItemStatusAsync(req.ItemId, status);
            if (updatedTaskItem is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }
            await Send.OkAsync(updatedTaskItem, ct);

    }
}
