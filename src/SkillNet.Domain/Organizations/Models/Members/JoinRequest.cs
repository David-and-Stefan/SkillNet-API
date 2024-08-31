using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Enums;
using SkillNet.Domain.Organizations.Models.Organizations;

namespace SkillNet.Domain.Organizations.Models.Members
{
    internal class JoinRequest : Entity<int>
    {
        internal JoinRequest(Member member, int groupId)
        {
            Member = member;
            GroupId = groupId;
            Status = Status.Pending;
            RequestedOn = DateTime.UtcNow;
        }

        public Member Member { get; private set; }
        public int GroupId { get; private set; }
        public Status Status { get; private set; }
        public DateTime RequestedOn { get; private set; }

        public void Approve()
        {
            if (Status != Status.Pending)
            {
                throw new InvalidOperationException("Only pending requests can be approved.");
            }

            Status = Status.Accepted;

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
