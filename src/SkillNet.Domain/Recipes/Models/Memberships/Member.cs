using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Recipes.Exceptions;

namespace SkillNet.Domain.Recipes.Models.Memberships
{
    using static ModelConstants.Member;

    internal class Member : Entity<int>
    {
        internal Member(string name, string email, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns)
        {
            this.Validate(name, email, bio, imageUrl, birthDate);

            this.Name = name;
            this.Email = email;
            this.Bio = bio;
            this.ImageUrl = imageUrl;
            this.BirthDate = birthDate;
            this.PhoneNumber = phoneNumber;
            this.Pronouns = pronouns;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }

        private void Validate(string name, string email, string bio, string imageUrl, DateTime birthDate)
        {
            this.ValidateName(name);
            this.ValidateEmail(email);
            this.ValidateBio(bio);
            this.ValidateImageUrl(imageUrl);
            this.ValidateBirthDate(birthDate);
        }
        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidMemberException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateEmail(string email) =>
            Guard.ForValidEmail<InvalidMemberException>(
                email,
                nameof(this.Name));



        private void ValidateBio(string bio) =>
            Guard.ForStringLength<InvalidMemberException>(
                bio,
                MinBioLength,
                MaxBioLength,
                nameof(this.Bio));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidMemberException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateBirthDate(DateTime birthDate) =>
            Guard.AgainstOutOfRange<InvalidMemberException>(
                birthDate,
                MinBirthDate,
                MaxBirthDate,
                nameof(this.BirthDate));
    }
}
