namespace SkillNet.Application.Common.Gateways
{
    using Domain.Common;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
