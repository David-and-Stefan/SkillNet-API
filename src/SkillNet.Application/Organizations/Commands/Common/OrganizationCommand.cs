namespace SkillNet.Application.Organizations.Commands.Common
{
    using SkillNet.Application.Common;

    public abstract class OrganizationCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
