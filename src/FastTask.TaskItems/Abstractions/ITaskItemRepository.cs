using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;

internal interface ITaskItemRepository : IReadOnlyTaskItemRepository
{
    Task CreateTaskItem(TaskItem newItem);
    Task UpdateTaskItemStatus(Guid id, ItemStatus status);
    Task DeleteTaskItem(Guid id);
}