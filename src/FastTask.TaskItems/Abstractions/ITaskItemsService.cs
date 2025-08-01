using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;

public interface ITaskItemsService
{
    Task CreateTaskItem(TaskItemDto newItem);
    Task<IReadOnlyList<TaskItemDto>> ListTaskItemsAsync();
    Task<TaskItemDto?> GetTaskItemById(Guid id);
    Task<IReadOnlyList<TaskItemDto>> ListTaskItemsByStatus(ItemStatus status);
    Task UpdateTaskItemStatus(Guid id, ItemStatus status);
    Task DeleteTaskItem(Guid id);
}
