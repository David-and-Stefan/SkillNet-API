using MediatR;
using SkillNet.Application.Common.Pagination;
using SkillNet.Application.Common.Pagination.Abstractions;
using SkillNet.Application.Organizations.Queries.Common;

namespace SkillNet.Application.Organizations.Queries.Search
{
    public class SearchOrganizationsQuery : OrganizationsQuery, IRequest<IPage<OrganizationOutputModel>>
    {
        public class SearchOrganizationsQueryHandler : OrganizationsQueryHandler,
            IRequestHandler<SearchOrganizationsQuery, IPage<OrganizationOutputModel>>
        {
            public SearchOrganizationsQueryHandler(IOrganizationQueryRepository repo) : base(repo)
            {
                
            }

            public async Task<IPage<OrganizationOutputModel>> Handle(SearchOrganizationsQuery request, CancellationToken cancellationToken)
            {
                var orgs = await base.GetOrganizations<OrganizationOutputModel>(request, cancellationToken);

                return orgs.ToPage();
            }
        }
    }
}
