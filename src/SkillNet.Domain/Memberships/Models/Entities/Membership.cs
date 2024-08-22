using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Memberships.Exceptions;

namespace SkillNet.Domain.Memberships.Models.Entities
{
    internal class Membership : Entity<int>
    { 

        internal Membership(Group group, Member member)
        {
            Validate(group, member);

            Group = group;
            Member = member;
            JoinedDate = DateTime.UtcNow;
            NextPaymentDueDate = JoinedDate.AddMonths(1);
            IsPaymentUpToDate = false;
        }
        public Group Group { get; private set; }
        public Member Member { get; private set; }
        public DateTime JoinedDate { get; private set; }
        public DateTime NextPaymentDueDate { get; private set; }
        public bool IsPaymentUpToDate { get; private set; }

        private void Validate(Group group, Member member)
        {
            if (group == null)
            {
                throw new InvalidMembershipException("Group cannot be null.");
            }

            if (member == null)
            {
                throw new InvalidMembershipException("Member cannot be null.");
            }
        }
    }
}
