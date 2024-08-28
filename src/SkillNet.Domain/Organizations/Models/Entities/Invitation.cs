using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Enums;
using SkillNet.Domain.Organizations.Exceptions;

namespace SkillNet.Domain.Organizations.Models.Entities
{
    internal class Invitation : Entity<int>
    {
        internal Invitation(Organization organization, int invitedEmployeeId)
        {
            Validate(organization, invitedEmployeeId);

            Organization = organization;
            InvitedEmployeeId = invitedEmployeeId;
            Status = Status.Pending;
        }

        public Organization Organization { get; private set; }
        public int InvitedEmployeeId { get; private set; }
        public Status Status { get; private set; }

        public void Accept(Employee member)
        {
            if (Status != Status.Pending)
            {
                throw new InvalidOperationException("Invitation is not pending.");
            }

            if (!InvitedEmployeeId.Equals(member.Id))
            {
                throw new InvalidOperationException("This invitation was not sent to this member.");
            }

            Status = Status.Accepted;

            Organization.AddEmployee(member);
        }

        public void Decline(Employee member)
        {
            if (Status != Status.Pending)
            {
                throw new InvalidOperationException("Invitation is not pending.");
            }

            if (!InvitedEmployeeId.Equals(member.Id))
            {
                throw new InvalidOperationException("This invitation was not sent to this member.");
            }

            Status = Status.Declined;
        }

        private void Validate(Organization organization, int invitedMemberId)
        {
            if (organization == null)
            {
                throw new InvalidInvitationException("Organization cannot be null.");
            }

            if (invitedMemberId <= 0)
            {
                throw new InvalidInvitationException("Invited member ID must be a positive integer.");
            }
        }
    }
}
