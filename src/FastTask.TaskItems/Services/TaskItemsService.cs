using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.Data;
using FastTask.TaskItems.DTOs;
using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Services;

public class TaskItemsService : ITaskItemsService
{
    private readonly ITaskItemsRepository _taskRepository;
    public TaskItemsService(ITaskItemsRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task CreateTaskItem(TaskItemDto newItem)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<TaskItemDto>> ListTaskItemsAsync()
    {
        var taskList = (await _taskRepository.ListTaskItemsAsync())
            .Select(t => new TaskItemDto(t.ItemId, t.Title, t.Description, t.Status, t.CreatedDate, t.UpdatedDate))
            .ToList();
        return taskList;
    }

    public async Task<TaskItemDto?> GetTaskItemByIdAsync(Guid id)
    {
        var task = await _taskRepository.GetTaskItemByIdAsync(id);
        return new TaskItemDto(task.ItemId, task.Title, task.Description, task.Status, task.CreatedDate, task.UpdatedDate);
    }

    public async Task<IReadOnlyList<TaskItemDto>> ListTaskItemsByStatusAsync(ItemStatus status)
    {
        var taskList = await _taskRepository.ListTaskItemsByStatusAsync(status);
        return [.. taskList.Select(item => new TaskItemDto(item.ItemId, item.Title, item.Description, item.Status, item.CreatedDate, item.UpdatedDate))];
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


