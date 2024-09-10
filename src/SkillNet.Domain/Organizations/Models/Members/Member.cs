using SkillNet.Domain.Common;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Events;
using SkillNet.Domain.Organizations.Exceptions;
using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Domain.Organizations.Models.Members
{
    using static ModelConstants.Member;
    public class Member : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Group> groups;
        private readonly HashSet<JoinRequest> joinRequests;

        internal Member(string name, string email)
        {
            Validate(name, email);

            Name = name;
            Email = email;
            groups = new HashSet<Group>();
            joinRequests = new HashSet<JoinRequest>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public IReadOnlyCollection<JoinRequest> JoinRequests => joinRequests.ToList().AsReadOnly();
        public IReadOnlyCollection<Group> Groups => groups.ToList().AsReadOnly();

        public void RequestToJoinGroup(int groupId)
        {
            if (groups.All(g => g.Id != groupId))
            {
                throw new InvalidOperationException("Member is already part of this group.");
            }

            var joinRequest = new JoinRequest(this, groupId);
            this.RaiseEvent(new JoinRequestCreatedEvent());
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
