namespace SkillNet.Infrastructure.Organizations.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SkillNet.Domain.Organizations.Models.Organizations;

    using static Domain.Organizations.Models.ModelConstants.Employee;
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(e => e.Bio)
                .IsRequired()
                .HasMaxLength(MaxBioLength);

            builder
                .Property(e => e.BirthDate)
                .IsRequired();

            builder
                .Property(e => e.Email)
                .IsRequired();

            builder
                .Property(e => e.ImageUrl)
                .IsRequired();

            builder.OwnsOne(e => e.PhoneNumber, p =>
            {
                p.WithOwner();

                p.Property(pn => pn.Number);
            });

            builder.OwnsOne(e => e.Pronouns, p =>
            {
                p.WithOwner();

                p.Property(p => p.Value);
            });

            builder.HasMany(e => e.ManagedGroups)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("managedGroups");
        }
    }
}
