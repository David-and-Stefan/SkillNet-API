

using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Infrastructure.Organizations.Configuration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using SkillNet.Domain.Organizations.Models;
    using SkillNet.Domain.Organizations.Models.Members;
    using static SkillNet.Domain.Organizations.Models.ModelConstants.Member;

    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder.Property(m => m.Email)
                .IsRequired();

            builder.HasMany<Group>("groups")
                .WithMany("members")
                .UsingEntity<Dictionary<string, object>>(
                    "MemberGroups",
                    j => j.HasOne<Group>()
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Member>()
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j =>
                    {
                        j.HasKey("MemberId", "GroupId");
                        j.ToTable("MemberGroups");
                    });

            builder.Navigation("groups")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany<JoinRequest>("joinRequests")
                .WithOne(jr => jr.Member)
                .HasForeignKey("MemberId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Navigation("joinRequests")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
