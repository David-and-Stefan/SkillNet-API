using System.Text.RegularExpressions;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Exceptions;

namespace SkillNet.Domain.Organizations.Models.Common
{
    using static ModelConstants.PhoneNumber;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            Validate(number);

            if (!Regex.IsMatch(number, PhoneNumberRegularExpression, RegexOptions.None, TimeSpan.FromMilliseconds(500)))
            {
                throw new InvalidPhoneNumberException("Phone number must start with a '+' and contain only digits afterwards.");
            }

            Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        private void Validate(string phoneNumber)
            => Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber,
                MinPhoneNumberLength,
                MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}
