﻿using System.Diagnostics.CodeAnalysis;
using SkillNet.Domain.Common;

namespace SkillNet.Domain.Organizations.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidInvitationException : BaseDomainException
    {
        public InvalidInvitationException()
        {

        }
        public InvalidInvitationException(string error) : base(error)
        {

        }
    }
}
