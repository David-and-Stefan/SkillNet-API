namespace SkillNet.Application.Organizations.Commands.Create
{
    using FluentValidation;
    using SkillNet.Application.Organizations.Commands.Common;
    using SkillNet.Domain.Organizations.Repositories;
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidator(IOrganizationDomainRepository carAdRepository)
            => this.Include(new OrganizationCommandValidator<CreateOrganizationCommand>());
    }
}
