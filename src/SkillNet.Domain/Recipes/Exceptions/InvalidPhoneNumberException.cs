using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Recipes.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidPronounsException : BaseDomainException
    {
        public InvalidPronounsException()
        {
            
        }

        public InvalidPronounsException(string error) : base(error)
        {

        }

    }
}
