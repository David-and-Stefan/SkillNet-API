using System.Runtime.CompilerServices;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Exceptions;
using SkillNet.Domain.Organizations.Models.Common;

[assembly: InternalsVisibleTo("SkillNet.Domain.UnitTests")]
namespace SkillNet.Domain.Organizations.Models.Organizations
{
    using static ModelConstants.Organizer;

    internal class Organizer : Entity<int>
    {
        internal Organizer(string name, string email, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns, Organization organization)
        {
            Validate(name, email, bio, imageUrl, birthDate);

            Name = name;
            Email = email;
            Bio = bio;
            ImageUrl = imageUrl;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Pronouns = pronouns;
            Organization = organization;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }
        public Organization Organization { get; private set; }

        private void Validate(string name, string email, string bio, string imageUrl, DateTime birthDate)
        {
            ValidateName(name);
            ValidateEmail(email);
            ValidateBio(bio);
            ValidateImageUrl(imageUrl);
            ValidateBirthDate(birthDate);
        }
        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidOrganizerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateEmail(string email) =>
            Guard.ForValidEmail<InvalidOrganizerException>(
                email,
                nameof(Email));


        private void ValidateBio(string bio) =>
            Guard.ForStringLength<InvalidOrganizerException>(
                bio,
                MinBioLength,
                MaxBioLength,
                nameof(Bio));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidOrganizerException>(
                imageUrl,
                nameof(ImageUrl));

        private void ValidateBirthDate(DateTime birthDate) =>
            Guard.AgainstOutOfRange<InvalidOrganizerException>(
                birthDate,
                MinBirthDate,
                MaxBirthDate,
                nameof(BirthDate));

    }
}
