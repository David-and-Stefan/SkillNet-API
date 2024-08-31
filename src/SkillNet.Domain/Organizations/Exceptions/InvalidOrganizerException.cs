using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Organizations.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidOrganizerException : BaseDomainException
    {
        public InvalidOrganizerException()
        {

        }
        public InvalidOrganizerException(string error) : base(error)
        {

        }
    }
}
