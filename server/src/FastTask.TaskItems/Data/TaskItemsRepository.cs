using FastTask.TaskItems.Abstractions;
using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;


namespace FastTask.TaskItems.Data;

public class TaskItemsRepository : ITaskItemsRepository
{
    private readonly TaskItemsDbContext _dbContext;

    public TaskItemsRepository(TaskItemsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TaskItem> CreateTaskItemAsync(TaskItem newItem)
    {
        _dbContext.TaskItems.Add(newItem);
        await _dbContext.SaveChangesAsync();
        return newItem;
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

    public async Task<TaskItem?> UpdateTaskItemStatusAsync(Guid itemId, ItemStatus status)
    {
        var taskItem = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.ItemId == itemId);
        if (taskItem is null)
        {
            return null;
        }
        taskItem.Status = status;
        taskItem.UpdatedDate = DateTime.UtcNow;
        _dbContext.TaskItems.Update(taskItem);
        await _dbContext.SaveChangesAsync();
        
        return taskItem;

    }

    public async Task<IAsyncResult?> DeleteTaskItemAsync(Guid itemId)
    {
        var taskItem = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.ItemId == itemId);
        if (taskItem is null)
        {
            return null;
        }
        _dbContext.Remove(taskItem);
        await _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
        
    }
}


