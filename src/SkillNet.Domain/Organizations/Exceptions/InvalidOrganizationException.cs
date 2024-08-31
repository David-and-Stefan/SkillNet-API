using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Organizations.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidOrganizationException : BaseDomainException
    {
        public InvalidOrganizationException()
        {

        }
        public InvalidOrganizationException(string error) : base(error)
        {

        }
    }
}
