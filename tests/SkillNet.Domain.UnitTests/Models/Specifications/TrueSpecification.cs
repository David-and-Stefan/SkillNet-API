using System.Linq.Expressions;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.UnitTests.Models.Specifications
{
    public class TrueSpecification : Specification<object>
    {
        public override Expression<Func<object, bool>> ToExpression() => o => true;
    }
}
