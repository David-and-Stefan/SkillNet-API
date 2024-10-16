﻿using SkillNet.Domain.Common.Models;

namespace SkillNet.Domain.UnitTests.Models.ValueObjects
{
    public class SimpleValueObject : ValueObject
    {
        private int intValue;
        private string stringValue;

        public SimpleValueObject(int intValue, string stringValue)
        {
            this.intValue = intValue;
            this.stringValue = stringValue;
        }
    }
}
