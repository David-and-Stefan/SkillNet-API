using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Exceptions;
using SkillNet.Domain.Organizations.Models.ValueObjects;

namespace SkillNet.Domain.Organizations.Models.Entities
{
    using static ModelConstants.Employee;

    internal class Employee : Entity<int>
    {

        private readonly HashSet<Group> managedGroups;

        internal Employee(string name, string email, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns)
        {
            Validate(name, email, bio, imageUrl, birthDate);

            Name = name;
            Email = email;
            Bio = bio;
            ImageUrl = imageUrl;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Pronouns = pronouns;

            managedGroups = new HashSet<Group>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }

        public IReadOnlyCollection<Group> ManagedGroups => managedGroups.ToList().AsReadOnly();

        public void AcceptInvitation(Invitation invitation)
        {
            invitation.Accept(this);
        }

        public void ManageGroup(Group group)
        {
            if (managedGroups.Any(g => g.Equals(group)))
            {
                throw new InvalidOperationException("Already managing this group.");
            }

            managedGroups.Add(group);
        }

        public void ApproveJoinRequest(JoinRequest request)
        {
            if (!managedGroups.Contains(request.Group))
            {
                throw new InvalidOperationException("This employee does not manage the specified group.");
            }

            request.Approve();
        }

        public void RejectJoinRequest(JoinRequest request)
        {
            if (!managedGroups.Contains(request.Group))
            {
                throw new InvalidOperationException("This employee does not manage the specified group.");
            }

            request.Reject();
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
            Guard.ForStringLength<InvalidEmployeeException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateEmail(string email) =>
            Guard.ForValidEmail<InvalidEmployeeException>(
                email,
                nameof(Name));



        private void ValidateBio(string bio) =>
            Guard.ForStringLength<InvalidEmployeeException>(
                bio,
                MinBioLength,
                MaxBioLength,
                nameof(Bio));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidEmployeeException>(
                imageUrl,
                nameof(ImageUrl));

        private void ValidateBirthDate(DateTime birthDate) =>
            Guard.AgainstOutOfRange<InvalidEmployeeException>(
                birthDate,
                MinBirthDate,
                MaxBirthDate,
                nameof(BirthDate));
    }
}
