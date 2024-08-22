using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Memberships.Enums;
using SkillNet.Domain.Memberships.Exceptions;
using SkillNet.Domain.Memberships.Models.ValueObjects;

namespace SkillNet.Domain.Memberships.Models.Entities
{
    using static ModelConstants.Member;

    internal class Member : Entity<int>
    {
        internal Member(string name, string email, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns)
        {
            Validate(name, email, bio, imageUrl, birthDate);

            Name = name;
            Email = email;
            Bio = bio;
            ImageUrl = imageUrl;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Pronouns = pronouns;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }

        public void AcceptInvitation(Invitation invitation)
        {
            invitation.Accept(this);
        }


        private void Validate(string name, string email, string bio, string imageUrl, DateTime birthDate)
        {
            ValidateName(name);
            ValidateEmail(email);
            ValidateBio(bio);
            ValidateImageUrl(imageUrl);
            ValidateBirthDate(birthDate);
        }
        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidMemberException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateEmail(string email) =>
            Guard.ForValidEmail<InvalidMemberException>(
                email,
                nameof(Name));



        private void ValidateBio(string bio) =>
            Guard.ForStringLength<InvalidMemberException>(
                bio,
                MinBioLength,
                MaxBioLength,
                nameof(Bio));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidMemberException>(
                imageUrl,
                nameof(ImageUrl));

        private void ValidateBirthDate(DateTime birthDate) =>
            Guard.AgainstOutOfRange<InvalidMemberException>(
                birthDate,
                MinBirthDate,
                MaxBirthDate,
                nameof(BirthDate));
    }
}
