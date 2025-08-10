using FastTask.TaskItems.Enums;
namespace FastTask.TaskItems.DTOs;

public record TaskItemDto(
    Guid ItemId,
    string Title,
    string Description,
    ItemStatus Status,
    DateTime? CreatedDate,
    DateTime? UpdatedDate
);

