namespace SkillNet.Application.Organizations
{
    using SkillNet.Application.Common.Gateways;
    using SkillNet.Application.Common.Pagination.Abstractions;
    using SkillNet.Domain.Common;
    using SkillNet.Domain.Organizations.Models.Organizations;
    using SkillNet.Application.Organizations.Queries.Details;

    public interface IOrganizationQueryRepository : IQueryRepository<Organization>
    {
        Task<IPagedList<TOutputModel>> GetOrganizations<TOutputModel>(
            Specification<Organization> orgSpecification,
            int pageNumber,
            int pageSize = 10,
            CancellationToken cancellationToken = default);

        Task<OrganizationDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
    }
}
