using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Enums;

namespace SkillNet.Domain.Organizations.Models.Entities
{
    internal class JoinRequest : Entity<int>
    {
        internal JoinRequest(Member member, Group group)
        {
            Member = member;
            Group = group;
            Status = Status.Pending;
            RequestedOn = DateTime.UtcNow;
        }

        public Member Member { get; private set; }
        public Group Group { get; private set; }
        public Status Status { get; private set; }
        public DateTime RequestedOn { get; private set; }

        public void Approve()
        {
            if (Status != Status.Pending)
            {
                throw new InvalidOperationException("Only pending requests can be approved.");
            }

            Status = Status.Accepted;
            Group.AddMember(Member);
        }

        public void Reject()
        {
            if (Status != Status.Pending)
            {
                throw new InvalidOperationException("Only pending requests can be rejected.");
            }

            Status = Status.Declined;
        }
    }
}
