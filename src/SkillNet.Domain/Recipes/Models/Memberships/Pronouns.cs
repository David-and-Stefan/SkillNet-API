﻿using System.Text.RegularExpressions;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Recipes.Exceptions;

namespace SkillNet.Domain.Recipes.Models.Memberships
{
    using static ModelConstants.Pronouns;

    public class Pronouns : ValueObject
    {
        internal Pronouns(string pronouns)
        {
            this.Validate(pronouns);

            if (!Regex.IsMatch(pronouns, PronounsRegularExpression, RegexOptions.None, TimeSpan.FromMilliseconds(500)))
            {
                throw new InvalidPronounsException("Pronouns must be in the format 'text/text', where each 'text' consists only of letters (a-z, A-Z). For example, 'she/her', 'they/them', or 'he/him'.");
            }

            this.Value = pronouns;
        }
        public string Value { get; }

        public static implicit operator string(Pronouns pronoun) => pronoun.Value;

        public static implicit operator Pronouns(string pronoun) => new Pronouns(pronoun);

        private void Validate(string pronouns)
            => Guard.ForStringLength<InvalidPronounsException>(
                pronouns,
                MinPronounsLength,
                MaxPronounsLength,
                nameof(Pronouns));
    }
}
