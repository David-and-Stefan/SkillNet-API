using SkillNet.Domain.Organizations.Models.Members;

namespace SkillNet.Infrastructure.Organizations.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SkillNet.Domain.Organizations.Models;
    using SkillNet.Domain.Organizations.Models.Organizations;

    using static SkillNet.Domain.Organizations.Models.ModelConstants.Group;

    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder.HasOne(g => g.Organization)
                .WithMany(o => o.Groups)
                .HasForeignKey("OrganizationId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Manager)
                .WithMany(e => e.ManagedGroups)
                .HasForeignKey("ManagerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Members)
                .WithMany(m => m.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "MemberGroups",
                    j => j.HasOne<Member>()
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Group>()
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j =>
                    {
                        j.HasKey("MemberId", "GroupId");
                        j.ToTable("MemberGroups");
                    });

            builder.Navigation(g => g.Members)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(g => g.JoinRequests)
                .WithOne()
                .HasForeignKey(jr => jr.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Navigation(g => g.JoinRequests)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
