using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Memberships.Enums;
using SkillNet.Domain.Memberships.Exceptions;

namespace SkillNet.Domain.Memberships.Models.Entities
{
    internal class Group : Entity<int>
    {
        private readonly HashSet<Membership> memberships;
        private readonly HashSet<Invitation> invitations;

        internal Group(string name, string description, double monthlyFee, Organizer organizer)
        {
            Validate(name, description, monthlyFee);

            Name = name;
            Description = description;
            Organizer = organizer;
            MonthlyFee = monthlyFee;

            memberships = new HashSet<Membership>();
            invitations = new HashSet<Invitation>();
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Organizer Organizer { get; private set; }
        public double MonthlyFee { get; private set; }

        public IReadOnlyCollection<Membership> Memberships => memberships.ToList().AsReadOnly();
        public IReadOnlyCollection<Invitation> Invitations => invitations.ToList().AsReadOnly();
        public bool IsMember(Member member) => memberships.Any(m => m.Member.Equals(member));

        public void AddInvitation(Invitation invitation)
        {
            if (invitations.Any(i =>
                    i.InvitedMemberId == invitation.InvitedMemberId && i.Status == InvitationStatus.Pending))
            {
                throw new InvalidOperationException("An invitation for this email is already pending.");
            }

            invitations.Add(invitation);
        }
        public void AddMember(Member member)
        {
            if (IsMember(member))
            {
                throw new InvalidOperationException("Member already exists.");
            }

            var membership = new Membership(this, member);
            memberships.Add(membership);
        }

        private void Validate(string name, string description, double monthlyFee)
        {
            ValidateName(name);
            ValidateDescription(description);
            ValidateMonthlyFee(monthlyFee);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidGroupException>(
                name,
                ModelConstants.Group.MinNameLength,
                ModelConstants.Group.MaxNameLength,
                nameof(Name));

        private void ValidateDescription(string description) =>
            Guard.ForStringLength<InvalidGroupException>(
                description,
                ModelConstants.Group.MinDescriptionLength,
                ModelConstants.Group.MaxDescriptionLength,
                nameof(Description));

        private void ValidateMonthlyFee(double monthlyFee)
        {
            if (monthlyFee < ModelConstants.Group.MinMonthlyFee)
            {
                throw new InvalidGroupException($"{nameof(MonthlyFee)} must be greater than or equal to {ModelConstants.Group.MinMonthlyFee}.");
            }
        }
    }
}
