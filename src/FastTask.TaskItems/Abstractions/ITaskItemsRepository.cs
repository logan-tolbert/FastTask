using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;

public interface ITaskItemsRepository : IReadOnlyTaskItemsRepository
{
    Task CreateTaskItem(TaskItem newItem);
    Task<TaskItem?> UpdateTaskItemStatusAsync(Guid itemId, ItemStatus status);
    Task<IAsyncResult?> DeleteTaskItemAsync(Guid itemId);
}