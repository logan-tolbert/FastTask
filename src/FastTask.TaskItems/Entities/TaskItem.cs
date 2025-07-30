using FastTask.TaskItems.Enums;
using Ardalis.GuardClauses;
namespace FastTask.TaskItems.Entities;

internal class TaskItem
{
    public Guid ItemId { get; set;}
    public string Title { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ItemStatus Status { get; set; } = ItemStatus.Pending;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set;}
    
    internal TaskItem(Guid itemId, string title, string description, ItemStatus status,  DateTime createdDate, DateTime updatedDate)
    {
        ItemId = Guard.Against.Default(itemId);
        Title = Guard.Against.NullOrWhiteSpace(title);
        Description = Guard.Against.NullOrWhiteSpace(description);
        Status = status;
        CreatedDate = createdDate;
    }
}

