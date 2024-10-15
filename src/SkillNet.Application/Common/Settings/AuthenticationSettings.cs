namespace SkillNet.Application.Common.Settings
{
    public class AuthenticationSettings
    {
        public string Audience { get; private set; } = default!;
        public string Authority { get; private set; } = default!;
    }
}
