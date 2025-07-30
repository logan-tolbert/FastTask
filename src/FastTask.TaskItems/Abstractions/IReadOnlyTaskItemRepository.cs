using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Abstractions;
internal interface IReadOnlyTaskItemRepository
{
    Task<List<TaskItem>> ListTaskItems();
    Task<TaskItem?> GetTaskItemById(Guid id);
    Task<List<TaskItem>> ListTaskItemsByStatus(ItemStatus status);
}