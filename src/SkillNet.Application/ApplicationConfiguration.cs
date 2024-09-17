using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillNet.Application.Common.Behaviours;
using SkillNet.Application.Common;
using System.Reflection;

namespace SkillNet.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(
                a => a = (ApplicationSettings)configuration.GetSection(nameof(ApplicationSettings)));
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }

    }
}
