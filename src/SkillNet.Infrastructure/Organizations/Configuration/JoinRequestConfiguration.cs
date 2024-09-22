namespace SkillNet.Infrastructure.Organizations.Configuration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using SkillNet.Domain.Organizations.Models.Members;
    using SkillNet.Domain.Organizations.Models.Organizations;
    internal class JoinRequestConfiguration : IEntityTypeConfiguration<JoinRequest>
    {
        public void Configure(EntityTypeBuilder<JoinRequest> builder)
        {
            builder.HasKey(jr => jr.Id);

            builder.Property(jr => jr.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(jr => jr.RequestedOn)
                .IsRequired();

            builder.HasOne(jr => jr.Member)
                .WithMany("joinRequests")
                .HasForeignKey("MemberId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Group>()
                .WithMany("joinRequests")
                .HasForeignKey(jr => jr.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
