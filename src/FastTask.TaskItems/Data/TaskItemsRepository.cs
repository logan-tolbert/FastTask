using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;
using Microsoft.EntityFrameworkCore;


namespace FastTask.TaskItems.Data;

public class TaskItemsRepository : ITaskItemsRepository
{
    private readonly TaskItemsDbContext _dbContext;

    public TaskItemsRepository(TaskItemsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task CreateTaskItem(TaskItem newItem)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<TaskItem>> ListTaskItemsAsync()
    {
        var taskList = await _dbContext.TaskItems.ToListAsync();
        return taskList;

    }

    public async Task<TaskItem?> GetTaskItemByIdAsync(Guid id)
    {
        var task = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.ItemId == id);
        return task;
    }

    public async Task<IReadOnlyList<TaskItem>> ListTaskItemsByStatusAsync(ItemStatus status)
    {
        var taskList = await _dbContext.TaskItems.Where(t => t.Status == status)
            .ToListAsync();
        return taskList;
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


