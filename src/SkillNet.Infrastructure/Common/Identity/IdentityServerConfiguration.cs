using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;

namespace SkillNet.Infrastructure.Common.Identity
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>()
            {

            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {

            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            return new List<Client>()
            {

            };
        }
    }
}
