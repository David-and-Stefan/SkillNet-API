using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Exceptions;

namespace SkillNet.Domain.Organizations.Models.Entities
{
    using static ModelConstants.Member;
    internal class Member : Entity<int>
    {
        private readonly HashSet<Group> groups;

        internal Member(string name, string email)
        {
            Validate(name, email);

            Name = name;
            Email = email;
            groups = new HashSet<Group>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<Group> Groups => groups.ToList().AsReadOnly();

        public void RequestToJoinGroup(Group group)
        {
            if (groups.Contains(group))
            {
                throw new InvalidOperationException("Member is already part of this group.");
            }

            var joinRequest = new JoinRequest(this, group);
            group.SubmitJoinRequest(joinRequest);
        }

        public void LeaveGroup(Group group)
        {
            if (!groups.Contains(group))
            {
                throw new InvalidOperationException("Member is not part of this group.");
            }

            group.RemoveMember(this);
            groups.Remove(group);
        }

        private void Validate(string name, string email)
        {
            ValidateName(name);
            ValidateEmail(email);
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
                nameof(Email));
    }
}
