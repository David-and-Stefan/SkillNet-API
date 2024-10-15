using SkillNet.Domain.Organizations.Exceptions;
using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Domain.Organizations.Factories.Organizations
{
    public class OrganizationFactory : IOrganizationFactory
    {
        private string organizationName = default!;
        private string organizationDescription = default!;
        private string organizationOwnerId = default!;

        private bool nameSet = false;
        private bool descriptionSet = false;
        private bool ownerSet = false;

        public IOrganizationFactory WithName(string name)
        {
            this.organizationName = name;
            this.nameSet = true;
            return this;
        }

        public IOrganizationFactory WithDescription(string description)
        {
            this.organizationDescription = description;
            this.descriptionSet = true;
            return this;
        }
        public IOrganizationFactory WithOwnerId(string ownerId)
        {
            this.organizationOwnerId = ownerId;
            this.ownerSet = true;
            return this;
        }

        public Organization Build()
        {
            if (!this.nameSet || !this.descriptionSet || !this.ownerSet)
            {
                throw new InvalidOrganizationException("Name and description must have values.");
            }

            return new Organization(
                this.organizationName,
                this.organizationDescription,
                this.organizationOwnerId);
        }
    }
}
