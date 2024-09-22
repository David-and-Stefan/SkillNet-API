namespace SkillNet.Infrastructure.Organizations.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SkillNet.Domain.Organizations.Models.Organizations;

    using static Domain.Organizations.Models.ModelConstants.Organization;
    using static Domain.Organizations.Models.ModelConstants.Common;
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(o => o.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .HasMany(o => o.Employees)
                .WithOne()
                .Metadata
                .PrincipalToDependent?
                .SetField("employees");

            builder
                .HasMany(o => o.Groups)
                .WithOne()
                .Metadata
                .PrincipalToDependent?
                .SetField("groups");
        }
    }
}
