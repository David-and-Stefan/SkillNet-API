using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillNet.Application.Common;
using SkillNet.Domain.Common;
using SkillNet.Infrastructure.Common.Persistence;
using SkillNet.Infrastructure.Organizations;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SkillNet.Application.Common.Settings;
using SkillNet.Infrastructure.Common.Events;

namespace SkillNet.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddIdentity(configuration)
                .AddTransient<IEventDispatcher, EventDispatcher>();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<SkillNetDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(SkillNetDbContext).Assembly.FullName)))
                .AddScoped<IOrganizationsDbContext>(provider => provider.GetService<SkillNetDbContext>());
        //.AddTransient<IInitializer, DatabaseInitializer>();

        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>)))
                    //.AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

        private static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opts =>
            {

                opts.Authority = "https://accounts.google.com";
                opts.Audience =
                    configuration.GetSection(nameof(AuthenticationSettings))[
                        nameof(AuthenticationSettings.ClientId)]!;
            });

            return services;
        }
    }
}
