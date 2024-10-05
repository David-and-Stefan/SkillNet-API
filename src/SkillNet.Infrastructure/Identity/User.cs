namespace SkillNet.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using SkillNet.Application.Identity;
    using SkillNet.Domain.Organizations.Models.Organizations;
    public class User : IdentityUser, IUser
    {
        public void BecomeOrganization(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
