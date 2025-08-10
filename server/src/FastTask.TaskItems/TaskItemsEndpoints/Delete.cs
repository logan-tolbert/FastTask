using FastEndpoints;
using FastTask.TaskItems.Abstractions;

namespace FastTask.TaskItems.TaskItemsEndpoints;

public record DeleteTaskItemRequest(Guid ItemId);
public class Delete(ITaskItemsService service) : Endpoint<DeleteTaskItemRequest>
{
    private readonly ITaskItemsService _service = service;
    public override void Configure()
    {
        Delete("/tasks/{itemid:guid}");
        AllowAnonymous();
        Description(builder =>
           builder
                  .ProducesProblemDetails(400, "application/json+problem")
                  .ProducesProblemDetails(404, "application/json+problem")
                  .ProducesProblemDetails(500, "application/json+problem")
           );
    }

    public override async Task HandleAsync(DeleteTaskItemRequest req, CancellationToken ct = default)
    {
        var result = await _service.DeleteTaskItemAsync(req.ItemId);
        if (result is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        await Send.OkAsync(ct);
        return;
    }
}
