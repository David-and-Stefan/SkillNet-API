using MediatR;
using SkillNet.Application.Common;

namespace SkillNet.Application.Organizations.Queries.Details
{
    public class DetailsOrganizationQuery : EntityCommand<int>, IRequest<OrganizationDetailsOutputModel>
    {
        public class OrganizationDetailsQueryHandler : IRequestHandler<DetailsOrganizationQuery, OrganizationDetailsOutputModel>
        {
            private readonly IOrganizationQueryRepository _repo;

            public OrganizationDetailsQueryHandler(IOrganizationQueryRepository repo)
            {
                _repo = repo;
            }

            public async Task<OrganizationDetailsOutputModel> Handle(DetailsOrganizationQuery request,
                CancellationToken cancellationToken)
            {
                var org = await _repo.GetDetails(request.Id, cancellationToken);

                return org;
            }
        }
    }
}
