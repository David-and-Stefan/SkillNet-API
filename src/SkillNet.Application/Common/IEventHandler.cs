namespace SkillNet.Application.Common
{
    using System.Threading.Tasks;
    using SkillNet.Domain.Common;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
