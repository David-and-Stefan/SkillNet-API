using SkillNet.Domain.Organizations.Models;

namespace SkillNet.Application.Organizations.Commands.Common
{
    using FluentValidation;
    using SkillNet.Application.Common;

    using static ModelConstants.Organization;
    public class OrganizationCommandValidator<TCommand> : AbstractValidator<OrganizationCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public OrganizationCommandValidator()
        {
            // Validate Name
            this.RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(MinNameLength).WithMessage($"Name must be at least {MinNameLength} characters long.")
                .MaximumLength(MaxNameLength).WithMessage($"Name cannot exceed {MaxNameLength} characters.");

            // Validate Description
            this.RuleFor(c => c.Description)
                .MaximumLength(MaxDescriptionLength).WithMessage($"Description cannot exceed {MaxDescriptionLength} characters.");
        }
    }
}
