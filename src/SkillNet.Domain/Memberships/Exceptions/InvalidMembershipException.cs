using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Memberships.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidMembershipException : BaseDomainException
    {
        public InvalidMembershipException()
        {

        }
        public InvalidMembershipException(string error) : base(error)
        {

        }
    }
}
