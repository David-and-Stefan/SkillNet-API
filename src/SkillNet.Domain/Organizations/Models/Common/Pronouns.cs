using System.Text.RegularExpressions;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Exceptions;

namespace SkillNet.Domain.Organizations.Models.Common
{
    using static ModelConstants.Pronouns;

    public class Pronouns : ValueObject
    {
        private Pronouns () { } //EFCore
        internal Pronouns(string pronouns)
        {
            Validate(pronouns);

            if (!Regex.IsMatch(pronouns, PronounsRegularExpression, RegexOptions.None, TimeSpan.FromMilliseconds(500)))
            {
                throw new InvalidPronounsException("Pronouns must be in the format 'text/text', where each 'text' consists only of letters (a-z, A-Z). For example, 'she/her', 'they/them', or 'he/him'.");
            }

            Value = pronouns;
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
