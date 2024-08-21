using System.Runtime.CompilerServices;
using SkillNet.Domain.Common;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Recipes.Exceptions;

[assembly: InternalsVisibleTo("SkillNet.Domain.UnitTests")]
namespace SkillNet.Domain.Recipes.Models.Memberships
{
    using static ModelConstants.Organizer;

    internal class Organizer : Entity<Guid>, IAggregateRoot
    {
        internal Organizer(string name, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns)
        {
            this.Validate(name, bio, imageUrl, birthDate);

            this.Name = name;
            this.Bio = bio;
            this.ImageUrl = imageUrl;
            this.BirthDate = birthDate;
            this.PhoneNumber = phoneNumber;
            this.Pronouns = pronouns;
        }

        public string Name { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }

        private void Validate(string name, string bio, string imageUrl, DateTime birthDate)
        {
            this.ValidateName(name);
            this.ValidateBio(bio);
            this.ValidateImageUrl(imageUrl);
            this.ValidateBirthDate(birthDate);
        }
        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidOrganizerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateBio(string bio) =>
            Guard.ForStringLength<InvalidOrganizerException>(
                bio,
                MinBioLength,
                MaxBioLength,
                nameof(this.Bio));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidOrganizerException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateBirthDate(DateTime birthDate) =>
            Guard.AgainstOutOfRange<InvalidOrganizerException>(
                birthDate,
                MinBirthDate,
                MaxBirthDate,
                nameof(this.BirthDate));

    }
}
