using AutoMapper;
using SkillNet.Application.Common.Mapping;
using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Application.Organizations.Queries.Common
{
    public class GroupViewModel : IMapFrom<Group>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string ManagerName { get; private set; } = default!;

        public int MemberCount { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper.CreateMap<Group, GroupViewModel>()
                .ForMember(grp => grp.ManagerName, cfg => cfg
                    .MapFrom(grp => grp.Manager.Name))
                .ForMember(grp => grp.MemberCount, cfg => cfg
                    .MapFrom(grp => grp.Members.Count));
    }
}
