using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillNet.Application.Common.Pagination.Abstractions;
using SkillNet.Domain.Common;
using SkillNet.Domain.Organizations.Models.Organizations;
using SkillNet.Domain.Organizations.Specifications;

namespace SkillNet.Application.Organizations.Queries.Common
{
    public abstract class OrganizationsQuery
    {
        public string? Name { get; set; }
        public string? OwnerId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public abstract class OrganizationsQueryHandler
        {
            private readonly IOrganizationQueryRepository _repo;

            public OrganizationsQueryHandler(IOrganizationQueryRepository repo)
            {
                _repo = repo;
            }

            protected async Task<IPagedList<TOutputModel>> GetOrganizations<TOutputModel>(
                OrganizationsQuery request, 
                CancellationToken cancellationToken = default)
            {
                var orgSpecification = this.GetOrgSpecification(request);

                return await this._repo.GetOrganizations<TOutputModel>(
                    orgSpecification,
                    request.Page,
                    request.PageSize,
                    cancellationToken
                );
            }

            private Specification<Organization> GetOrgSpecification(OrganizationsQuery request)
                => new OrganizationNameSpecification(request.Name).And(
                    new OrganizationOwnerSpecification(request.OwnerId));
        }
    }
}
