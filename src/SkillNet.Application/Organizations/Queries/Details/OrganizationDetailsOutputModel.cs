
namespace SkillNet.Application.Organizations.Queries.Details
{
    using AutoMapper;
    using SkillNet.Application.Organizations.Queries.Common;
    using SkillNet.Domain.Organizations.Models.Organizations;

    public class OrganizationDetailsOutputModel : OrganizationOutputModel
    {
        public IReadOnlyCollection<EmployeeOutputModel> Employees { get; private set; } = default!;

        public IReadOnlyCollection<GroupViewModel> Groups { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Organization, OrganizationDetailsOutputModel>()
                .IncludeBase<Organization, OrganizationOutputModel>()
                .ForMember(org => org.Employees, cfg => cfg
                    .MapFrom(org => org.Employees))
                .ForMember(org => org.Groups, cfg => cfg
                    .MapFrom(org => org.Groups));

    }
}
