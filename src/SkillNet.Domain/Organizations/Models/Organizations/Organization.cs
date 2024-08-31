using SkillNet.Domain.Common;
using SkillNet.Domain.Common.Models;
using SkillNet.Domain.Organizations.Enums;
using SkillNet.Domain.Organizations.Exceptions;

namespace SkillNet.Domain.Organizations.Models.Organizations
{
    using static ModelConstants.Organization;

    internal class Organization : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Employee> employees;
        private readonly HashSet<Group> groups;

        internal Organization(string name, string description, Organizer organizer)
        {
            Validate(name, description);

            Name = name;
            Description = description;
            Organizer = organizer;

            employees = new HashSet<Employee>();
            groups = new HashSet<Group>();
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Organizer Organizer { get; private set; }

        public IReadOnlyCollection<Employee> Employees => employees.ToList().AsReadOnly();
        public bool IsEmployee(Employee member) => employees.Any(e => e.Equals(member));

        public void CreateGroup(string name, string description, int employeeId)
        {
            var employee = employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee not assigned to organization.");
            }

            var group = new Group(name, description, this, employee);

            employee.ManageGroup(group);
            groups.Add(group);
        }
        public void AddEmployee(Employee employee)
        {
            if (IsEmployee(employee))
            {
                throw new InvalidOperationException("Member already exists.");
            }

            employees.Add(employee);
        }

        private void Validate(string name, string description)
        {
            ValidateName(name);
            ValidateDescription(description);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidOrganizationException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        private void ValidateDescription(string description) =>
            Guard.ForStringLength<InvalidOrganizationException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(Description));

    }
}
