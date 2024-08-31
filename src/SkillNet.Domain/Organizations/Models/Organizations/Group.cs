using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Enums;
using SkillNet.Domain.Organizations.Exceptions;
using SkillNet.Domain.Organizations.Models.Members;

namespace SkillNet.Domain.Organizations.Models.Organizations
{
    using static ModelConstants.Group;
    internal class Group : Entity<int>
    {
        private readonly HashSet<Member> members;
        private readonly HashSet<JoinRequest> joinRequests;

        internal Group(string name, string description, Organization organization, Employee manager)
        {
            Validate(name, description);

            Name = name;
            Description = description;
            Organization = organization;
            Manager = manager;

            members = new HashSet<Member>();
            joinRequests = new HashSet<JoinRequest>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Organization Organization { get; private set; }
        public Employee Manager { get; private set; }
        public IReadOnlyCollection<Member> Members => members.ToList().AsReadOnly();
        public IReadOnlyCollection<JoinRequest> JoinRequests => joinRequests.ToList().AsReadOnly();

        public void AddMember(Member member)
        {
            if (members.Any(m => m.Equals(member)))
            {
                throw new InvalidOperationException("Member already exists in the group.");
            }

            members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            if (!members.Contains(member))
            {
                throw new InvalidOperationException("Member does not exist in the group.");
            }

            members.Remove(member);
        }

        public void SubmitJoinRequest(JoinRequest request)
        {
            if (joinRequests.Any(r => r.Member == request.Member && r.Status == Status.Pending))
            {
                throw new InvalidOperationException("A pending request already exists for this member.");
            }

            joinRequests.Add(request);
        }

        private void Validate(string name, string description)
        {
            ValidateName(name);
            ValidateDescription(description);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidGroupException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateDescription(string description) =>
            Guard.ForStringLength<InvalidGroupException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(Description));
    }
}
