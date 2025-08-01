using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;

public interface ITaskItemsRepository : IReadOnlyTaskItemsRepository
{
    Task CreateTaskItem(TaskItem newItem);
    Task UpdateTaskItemStatus(Guid id, ItemStatus status);
    Task DeleteTaskItem(Guid id);
}