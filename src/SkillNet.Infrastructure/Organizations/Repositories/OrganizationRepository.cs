using AutoMapper;
using SkillNet.Domain.Organizations.Models.Organizations;
using SkillNet.Domain.Organizations.Repositories;
using SkillNet.Infrastructure.Common.Persistence;

namespace SkillNet.Infrastructure.Organizations.Repositories
{
    internal class OrganizationRepository : DataRepository<IOrganizationsDbContext, Organization>, IOrganizationDomainRepository
    {
        private readonly IMapper _mapper;
        public OrganizationRepository(IOrganizationsDbContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

    }
}
