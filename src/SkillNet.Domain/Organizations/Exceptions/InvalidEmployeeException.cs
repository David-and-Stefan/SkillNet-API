using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Organizations.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidEmployeeException : BaseDomainException
    {
        public InvalidEmployeeException()
        {

        }
        public InvalidEmployeeException(string error) : base(error)
        {

        }
    }
}
