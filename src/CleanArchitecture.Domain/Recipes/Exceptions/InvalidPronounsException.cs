using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Recipes.Exceptions
{
    public class InvalidPhoneNumberException : BaseDomainException
    {
        [ExcludeFromCodeCoverage]
        public InvalidPhoneNumberException()
        {
            
        }
        public InvalidPhoneNumberException(string error) : base(error)
        {

        }

    }
}
