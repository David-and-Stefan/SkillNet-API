namespace SkillNet.Domain.Organizations.Specifications
{
    using SkillNet.Domain.Common;
    using SkillNet.Domain.Organizations.Models.Organizations;
    using System.Linq.Expressions;
    public class OrganizationNameSpecification : Specification<Organization>
    {
        private readonly string? name;

        public OrganizationNameSpecification(string? name) => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Organization, bool>> ToExpression()
            => org => org.Name.Contains(this.name!);
    }
}
