using AutoMapper;
using SkillNet.Application.Common.Mapping;
using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Application.Organizations.Queries.Common
{
    public class OrganizationOutputModel : IMapFrom<Organization>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string OwnerId { get; private set; } = default!;

    }
}
