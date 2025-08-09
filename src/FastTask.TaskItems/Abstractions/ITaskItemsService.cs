using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;

public interface ITaskItemsService
{
    Task CreateTaskItem(TaskItemDto newItem);
    Task<IReadOnlyList<TaskItemDto>> ListTaskItemsAsync();
    Task<TaskItemDto?> GetTaskItemByIdAsync(Guid id);
    Task<IReadOnlyList<TaskItemDto>> ListTaskItemsByStatusAsync(ItemStatus status);
    Task<TaskItemDto?> UpdateTaskItemStatusAsync(Guid itemId, ItemStatus status);
    Task<IAsyncResult?> DeleteTaskItemAsync(Guid itemId);
}
