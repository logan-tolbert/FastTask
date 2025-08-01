using FastTask.TaskItems.Entities;
using FastTask.TaskItems.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTask.TaskItems.Data;

internal class TaskItemsConfiguration : IEntityTypeConfiguration<TaskItem>
{

    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        // Integer PK with identity
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();

        // Guid for external use - unique index for fast lookups
        builder.Property(t => t.ItemId)
            .IsRequired();
        builder.HasIndex(t => t.ItemId)
            .IsUnique();

        builder.Property(p => p.Title)
            .HasColumnType("nvarchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("nvarchar")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.CreatedDate)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .HasDefaultValueSql("GetUtcDate()")
            .IsRequired();

        builder.Property(p => p.UpdatedDate)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);
        builder.HasData(GetSampleData());
    }

    internal static List<TaskItem> GetSampleData()
    {
        return
        [
           new TaskItem{ Id = 1, ItemId = new Guid("f7cb95b9-b1ed-48b8-82c2-bd2495e97d8e"), Title="Design user authentication system",Description="Create wireframes and technical specifications for user login, registration, and password reset functionality",Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 2, ItemId = new Guid("b6781c6f-8dba-4ad9-b1f4-448d28e462b5"), Title="Implement API endpoints", Description="Develop REST API endpoints for user management and task operations", Status = ItemStatus.InProgress, UpdatedDate = null },
           new TaskItem{ Id = 3, ItemId = new Guid("157f3f13-3f09-4579-90bd-2964660f2a84"), Title="Set up CI/CD pipeline", Description="Configure automated testing and deployment pipeline using GitHub Actions", Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 4, ItemId = new Guid("69b46755-9d5a-4889-a491-b2611b11eb2c"), Title="Database migration scripts", Description="Write migration scripts to update production database schema", Status = ItemStatus.Completed, UpdatedDate = null },
           new TaskItem{ Id = 5, ItemId = new Guid("c9d595c4-d174-4566-af43-f2836d724f4a"), Title="Code review for payment module", Description="Review pull request #247 for payment processing implementation", Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 6, ItemId = new Guid("a6bd6b37-4f5c-43d6-aeba-63faa69550c6"), Title="Update documentation", Description="Revise API documentation to reflect recent endpoint changes", Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 7, ItemId = new Guid("f7d414ee-490e-4649-a732-d70dad1a6299"), Title="Performance optimization", Description="Optimize database queries for the dashboard loading time", Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 8, ItemId = new Guid("cb63221d-6cf6-4aea-82b6-100fb690fb5d"), Title="Security audit", Description="Conduct security review of authentication and authorization mechanisms", Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 9, ItemId = new Guid("2aaeab2e-5035-4eab-8c4a-688daa257294"), Title="Mobile app testing", Description="Test mobile application on various devices and screen sizes", Status = ItemStatus.Pending, UpdatedDate = null },
           new TaskItem{ Id = 10, ItemId = new Guid("5973cb0f-63c4-4c09-9f8b-8758dfda286a"), Title="Client presentation preparation", Description="Prepare demo and presentation materials for upcoming client meeting", Status = ItemStatus.Pending, UpdatedDate = null }
        ];
    }

}
