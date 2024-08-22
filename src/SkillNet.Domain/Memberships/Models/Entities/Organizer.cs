using System.Runtime.CompilerServices;
using SkillNet.Domain.Common;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Memberships.Exceptions;
using SkillNet.Domain.Memberships.Models.ValueObjects;

[assembly: InternalsVisibleTo("SkillNet.Domain.UnitTests")]
namespace SkillNet.Domain.Memberships.Models.Entities
{
    using static ModelConstants.Organizer;

    internal class Organizer : Entity<int>, IAggregateRoot
    {
        public HashSet<Group> groups;

        internal Organizer(string name, string email, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns)
        {
            Validate(name, email, bio, imageUrl, birthDate);

            Name = name;
            Email = email;
            Bio = bio;
            ImageUrl = imageUrl;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Pronouns = pronouns;

            groups = new HashSet<Group>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }

        public IReadOnlyCollection<Group> Groups => groups.ToList().AsReadOnly();


        public void CreateGroup(string name, string description, double monthlyFee)
        {
            var group = new Group(name, description, monthlyFee, this);
            if (groups.All(g => g.Name != name))
            {
                groups.Add(group);
            }
        }

        public void InviteMemberToGroup(int groupId, int memberId)
        {
            var group = groups.FirstOrDefault(g => g.Id == groupId);
            if (group is null)
            {
                throw new InvalidOperationException("Group not managed by organizer.");
            }

            var invitation = new Invitation(group, memberId);
            group.AddInvitation(invitation);

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
            Guard.ForStringLength<InvalidOrganizerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateEmail(string email) =>
            Guard.ForValidEmail<InvalidOrganizerException>(
                email,
                nameof(Name));



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
