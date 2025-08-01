using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;
public interface IReadOnlyTaskItemsRepository
{
    Task<IReadOnlyList<TaskItem>> ListTaskItemsAsync();
    Task<TaskItem?> GetTaskItemById(Guid id);
    Task<IReadOnlyList<TaskItem>> ListTaskItemsByStatus(ItemStatus status);
}