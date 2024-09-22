namespace SkillNet.Application.Identity
{
    using SkillNet.Domain.Organizations.Models.Organizations;

    public interface IUser
    {
        void BecomeOrganization(Organization organization);
    }
}
