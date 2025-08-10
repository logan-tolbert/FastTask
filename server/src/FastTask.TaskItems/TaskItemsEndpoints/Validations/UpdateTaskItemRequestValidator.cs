using FastEndpoints;
using FluentValidation;


namespace FastTask.TaskItems.TaskItemsEndpoints.Validations;

public class UpdateTaskItemStatusRequestValidator : Validator<UpdateTaskItemStatusRequest>
{
    private static readonly IReadOnlyList<string> AllowedStatusValues = ["pending", "inprogress", "completed", "archived"];
    public UpdateTaskItemStatusRequestValidator()
    {
        RuleFor(req => req.ItemId)
          .NotNull()
          .NotEqual(Guid.Empty)
          .WithMessage("The task item id is required");

        RuleFor(req => req.Status)
            .NotNull()
            .Must(s => AllowedStatusValues.Contains(s))
            .WithMessage("Status must be 'pending', 'inprogress', 'completed', or 'archived'");
    }
}
