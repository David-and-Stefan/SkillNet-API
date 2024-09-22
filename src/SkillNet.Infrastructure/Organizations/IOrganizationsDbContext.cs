namespace SkillNet.Infrastructure.Organizations
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using SkillNet.Domain.Organizations.Models.Members;
    using SkillNet.Domain.Organizations.Models.Organizations;
    internal interface IOrganizationsDbContext : IDbContext
    {
        DbSet<Organization> Organizations { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Group> Groups { get; }
        DbSet<Member> Members { get; }
        DbSet<JoinRequest> JoinRequests { get; }
    }
}
