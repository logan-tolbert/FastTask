using FastTask.TaskItems.Enums;
using Ardalis.GuardClauses;
using NJsonSchema.Annotations;
namespace FastTask.TaskItems.Entities;

public class TaskItem
{
    public int Id { get; set; } // Internal PK
    public Guid ItemId { get; set;} // External Identifier
    public string Title { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ItemStatus Status { get; set; } = ItemStatus.Pending;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; } = null;
    
    public TaskItem() { }
    public TaskItem(string title, string description, ItemStatus status)
    {
        ItemId = Guid.NewGuid();
        Title = Guard.Against.NullOrWhiteSpace(title);
        Description = Guard.Against.NullOrWhiteSpace(description);
        Status = Guard.Against.EnumOutOfRange(status);
        CreatedDate = DateTime.UtcNow;
    }
}

