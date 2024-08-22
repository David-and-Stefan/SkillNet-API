﻿using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Recipes.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidMemberException : BaseDomainException
    {
        public InvalidMemberException()
        {

        }
        public InvalidMemberException(string error) : base(error)
        {

        }
    }
}
