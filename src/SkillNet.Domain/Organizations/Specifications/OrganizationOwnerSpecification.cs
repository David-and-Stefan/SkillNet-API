namespace SkillNet.Domain.Organizations.Specifications
{
    using SkillNet.Domain.Common;
    using SkillNet.Domain.Organizations.Models.Organizations;
    using System.Linq.Expressions;
    public class OrganizationOwnerSpecification : Specification<Organization>
    {
        private readonly string? ownerId;

        public OrganizationOwnerSpecification(string? ownerId) => this.ownerId = ownerId;

        protected override bool Include => this.ownerId != null;

        public override Expression<Func<Organization, bool>> ToExpression()
            => org => org.OwnerId == this.ownerId!;
    }
}
