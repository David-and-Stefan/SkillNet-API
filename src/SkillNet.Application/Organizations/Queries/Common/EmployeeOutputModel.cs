namespace SkillNet.Application.Organizations.Queries.Common
{
    using AutoMapper;
    using SkillNet.Application.Common.Mapping;
    using SkillNet.Domain.Organizations.Models.Organizations;
    public class EmployeeOutputModel : IMapFrom<Employee>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string Bio { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public DateTime BirthDate { get; private set; }

        public string PhoneNumber { get; private set; } = default!;

        public string Pronouns { get; private set; } = default!;
    }
}
