using Ardalis.GuardClauses;
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

    public async Task<TaskItemDto?> UpdateTaskItemStatusAsync(Guid itemId, ItemStatus status)
    {
        var updatedTask = await _taskRepository.UpdateTaskItemStatusAsync(itemId, status);
        if (updatedTask is null)
        {
            return null;
        }
        return new TaskItemDto(updatedTask.ItemId, updatedTask.Title, updatedTask.Description, updatedTask.Status, updatedTask.CreatedDate, updatedTask.UpdatedDate);
    }

    public async Task<IAsyncResult?> DeleteTaskItemAsync(Guid itemId)
    {
        var result = await _taskRepository.DeleteTaskItemAsync(itemId);
        if (result is null)
        {
            return null;
        }
        return result;
    }
}


