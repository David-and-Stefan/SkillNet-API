using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Memberships.Exceptions
{
    public class InvalidPronounsException : BaseDomainException
    {
        [ExcludeFromCodeCoverage]
        public InvalidPronounsException()
        {
            
        }
        public InvalidPronounsException(string error) : base(error)
        {

        }

    }
}
