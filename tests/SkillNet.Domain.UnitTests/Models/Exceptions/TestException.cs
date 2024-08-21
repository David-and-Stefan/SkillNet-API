using SkillNet.Domain.Common;

namespace SkillNet.Domain.UnitTests.Models.Exceptions
{
    public class TestException : BaseDomainException
    {
        public TestException()
        {
            
        }

        public TestException(string message) : base(message)
        {
            
        }
    }
}
