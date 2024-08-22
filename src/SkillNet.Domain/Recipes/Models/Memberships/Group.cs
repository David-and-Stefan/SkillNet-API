using SkillNet.Domain.Common.Models;

namespace SkillNet.Domain.Recipes.Models.Memberships
{
    internal class Group : Entity<int>
    {
        private readonly HashSet<Membership> memberships;

        internal Group(string name, string description, Organizer organizer)
        {
            this.Name = name;
            this.Description = description;
            this.Organizer = organizer;

            memberships = new HashSet<Membership>();
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Organizer Organizer { get; private set; }

        public IReadOnlyCollection<Membership> Memberships => memberships.ToList().AsReadOnly();
        public bool IsMember(Member member) => memberships.Any(m => m.Member.Equals(member));


    }
}
