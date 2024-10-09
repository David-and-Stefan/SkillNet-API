using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillNet.Application.Common.Behaviours;
using System.Reflection;
using SkillNet.Application.Common.Settings;

namespace SkillNet.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationSettings>(
                a => a = (AuthenticationSettings)configuration.GetSection(nameof(AuthenticationSettings)));
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }

    }
}
