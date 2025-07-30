using FastTask.TaskItems.Enums;

namespace FastTask.TaskItems.Entities;

internal class TaskItem
{
    public Guid ItemId { get; set;}
    public string Title { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ItemStatus Status { get; set; } = ItemStatus.Pending;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set;}
    
}

