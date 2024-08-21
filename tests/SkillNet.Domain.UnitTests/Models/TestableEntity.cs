using SkillNet.Domain.Common;
using SkillNet.Domain.Common.Models;

namespace SkillNet.Domain.UnitTests.Models
{
    public class TestableEntity : Entity<int>
    {
        public void TestRaiseEvent(IDomainEvent domainEvent)
        {
            RaiseEvent(domainEvent);
        }
    }
}
