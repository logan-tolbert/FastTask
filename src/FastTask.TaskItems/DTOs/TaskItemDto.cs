using FastTask.TaskItems.Enums;
namespace FastTask.TaskItems.DTOs;

public record TaskItemDto(
    Guid Id,
    string Title,
    string Description,
    ItemStatus Status,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

