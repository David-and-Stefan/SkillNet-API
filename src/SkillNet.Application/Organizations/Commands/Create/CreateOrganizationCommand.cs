namespace SkillNet.Application.Organizations.Commands.Create
{
    using MediatR;
    using SkillNet.Application.Organizations.Commands.Common;
    using SkillNet.Domain.Organizations.Factories.Organizations;
    using SkillNet.Domain.Organizations.Repositories;

    public class CreateOrganizationCommand : OrganizationCommand<CreateOrganizationCommand>, IRequest<CreateOrganizationOutputModel>
    {
        public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, CreateOrganizationOutputModel>
        {
            private readonly IOrganizationFactory _organizationFactory;
            private readonly IOrganizationDomainRepository _organizationRepository;

            public CreateOrganizationCommandHandler(
                IOrganizationFactory organizationFactory,
                IOrganizationDomainRepository organizationRepository)
            {
                _organizationFactory = organizationFactory;
                _organizationRepository = organizationRepository;
            }

            public async Task<CreateOrganizationOutputModel> Handle(
                CreateOrganizationCommand request,
                CancellationToken cancellationToken)
            {
                var organization = _organizationFactory
                    .WithName(request.Name)
                    .WithDescription(request.Description)
                    .Build();

                await _organizationRepository.Save(organization, cancellationToken);

                return new CreateOrganizationOutputModel(organization.Id);
            }
        }
    }
}
