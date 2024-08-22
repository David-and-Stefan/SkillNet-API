using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Memberships.Enums;
using SkillNet.Domain.Memberships.Exceptions;

namespace SkillNet.Domain.Memberships.Models.Entities
{
    internal class Invitation : Entity<int>
    {
        internal Invitation(Group group, int invitedMemberId)
        {
            Validate(group, invitedMemberId);

            Group = group;
            InvitedMemberId = invitedMemberId;
            Status = InvitationStatus.Pending;
        }

        public Group Group { get; private set; }
        public int InvitedMemberId { get; private set; }
        public InvitationStatus Status { get; private set; }

        public void Accept(Member member)
        {
            if (Status != InvitationStatus.Pending)
            {
                throw new InvalidOperationException("Invitation is not pending.");
            }

            if (!InvitedMemberId.Equals(member.Id))
            {
                throw new InvalidOperationException("This invitation was not sent to this member.");
            }

            Status = InvitationStatus.Accepted;

            Group.AddMember(member);
        }

        public void Decline(Member member)
        {
            if (Status != InvitationStatus.Pending)
            {
                throw new InvalidOperationException("Invitation is not pending.");
            }

            if (!InvitedMemberId.Equals(member.Id))
            {
                throw new InvalidOperationException("This invitation was not sent to this member.");
            }

            Status = InvitationStatus.Declined;
        }

        private void Validate(Group group, int invitedMemberId)
        {
            if (group == null)
            {
                throw new InvalidInvitationException("Group cannot be null.");
            }

            if (invitedMemberId <= 0)
            {
                throw new InvalidInvitationException("Invited member ID must be a positive integer.");
            }
        }

    }
}
