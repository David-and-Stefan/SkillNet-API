using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Memberships.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidGroupException : BaseDomainException
    {
        public InvalidGroupException()
        {

        }
        public InvalidGroupException(string error) : base(error)
        {

        }
    }
}
