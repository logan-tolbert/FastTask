using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;

internal interface ITaskItemService
{
    Task CreateTaskItem(TaskItemDto newItem);
    Task<List<TaskItemDto>> ListTaskItems();
    Task<TaskItemDto?> GetTaskItemById(Guid id);
    Task<List<TaskItemDto>> ListTaskItemsByStatus(ItemStatus status);
    Task UpdateTaskItemStatus(Guid id, ItemStatus status);
    Task DeleteTaskItem(Guid id);
}
