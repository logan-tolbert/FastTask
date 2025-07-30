using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Services;

internal class TaskItemService : ITaskItemService
{
    private readonly TaskItemRepository _todoRepository;
    public TaskItemService(TaskItemRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task CreateTaskItem(TaskItemDto newItem)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskItemDto>> ListTaskItems()
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemDto?> GetTaskItemById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskItemDto>> ListTaskItemsByStatus(ItemStatus status)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTaskItemStatus(Guid id, ItemStatus status)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTaskItem(Guid id)
    {
        throw new NotImplementedException();
    }
}

internal class TaskItemRepository : ITaskItemRepository
{
    public Task CreateTaskItem(TaskItem newItem)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskItem>> ListTaskItems()
    {
        throw new NotImplementedException();
    }
    public Task<TaskItem?> GetTaskItemById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskItem>> ListTaskItemsByStatus(ItemStatus status)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTaskItemStatus(Guid id, ItemStatus status)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTaskItem(Guid id)
    {
        throw new NotImplementedException();
    }
}
