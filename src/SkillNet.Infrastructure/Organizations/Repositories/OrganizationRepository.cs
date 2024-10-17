using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SkillNet.Application.Common.Exceptions;
using SkillNet.Application.Common.Pagination;
using SkillNet.Application.Common.Pagination.Abstractions;
using SkillNet.Application.Organizations;
using SkillNet.Application.Organizations.Queries.Details;
using SkillNet.Domain.Common;
using SkillNet.Domain.Organizations.Models.Organizations;
using SkillNet.Domain.Organizations.Repositories;
using SkillNet.Infrastructure.Common.Persistence;

namespace SkillNet.Infrastructure.Organizations.Repositories
{
    internal class OrganizationRepository : DataRepository<IOrganizationsDbContext, Organization>, IOrganizationDomainRepository, IOrganizationQueryRepository
    {
        private readonly IMapper _mapper;
        public OrganizationRepository(IOrganizationsDbContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

        public async Task<IPagedList<TOutputModel>> GetOrganizations<TOutputModel>(Specification<Organization> orgSpecification, int pageNumber = 0, int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var totalCount = Data.Organizations.Count(orgSpecification);

            var orgs = Data.Organizations
                .Where(orgSpecification)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
            .ToList();

            var mappedPosts = _mapper.Map<List<TOutputModel>>(orgs);

            var totalPages = 0;
            if (totalCount > 0)
            {
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            }

            return new PagedList<TOutputModel>(mappedPosts, pageNumber, pageSize, totalPages, totalCount);
        }

        public async Task<OrganizationDetailsOutputModel> GetDetails(int id,
            CancellationToken cancellationToken = default)
        {
            var org = await this
                .All()
                .Include(o => o.Employees)
                .Include(o => o.Groups)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (org is null)
            {
                throw new NotFoundException("Organization doesn't exist.", id);
            }

            var mappedOrg = _mapper.Map<OrganizationDetailsOutputModel>(org);
            return mappedOrg;
        }
    }
}
