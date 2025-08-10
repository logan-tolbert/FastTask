using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;
public interface IReadOnlyTaskItemsRepository
{
    Task<IReadOnlyList<TaskItem>> ListTaskItemsAsync();
    Task<TaskItem?> GetTaskItemByIdAsync(Guid id);
    Task<IReadOnlyList<TaskItem>> ListTaskItemsByStatusAsync(ItemStatus status);
}