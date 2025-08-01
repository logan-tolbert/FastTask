using FastTask.TaskItems.Abstractions;
using FastEndpoints;
using FastTask.TaskItems.DTOs;
using Microsoft.AspNetCore.Http;

namespace FastTask.TaskItems.TaskItemsEndpoints;

public record GetTaskItemByIdRequest(Guid Id);

public class GetById(ITaskItemsService service) : Endpoint<GetTaskItemByIdRequest, TaskItemDto>
{
    private readonly ITaskItemsService _service = service;

    public override void Configure()
    {
        Get("/tasks/{id:guid}");
        AllowAnonymous();
        Description(builder =>
            builder
                   .ProducesProblemDetails(400, "application/json+problem")
                   .ProducesProblemDetails(500, "application/json+problem"),
                   clearDefaults: true
            );
    }

    public override async Task HandleAsync(GetTaskItemByIdRequest req,
        CancellationToken ct)
    {
        var task = await _service.GetTaskItemById(req.Id);
        if (task == null)
        {
            await Send.NotFoundAsync();
            return;
        }
        await Send.OkAsync(task);
    }
}
