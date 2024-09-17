using SkillNet.Domain.Common;
using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Domain.Organizations.Factories.Organizations
{
    public interface IOrganizationFactory : IFactory<Organization>
    {
        IOrganizationFactory WithName(string name);
        IOrganizationFactory WithDescription(string description);
    }
}
