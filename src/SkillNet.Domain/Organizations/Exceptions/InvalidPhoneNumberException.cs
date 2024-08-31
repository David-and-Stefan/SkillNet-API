using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Organizations.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
            
        }

        public InvalidPhoneNumberException(string error) : base(error)
        {

        }

    }
}
