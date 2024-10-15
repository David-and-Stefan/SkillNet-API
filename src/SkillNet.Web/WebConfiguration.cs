using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace SkillNet.Web
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using SkillNet.Application.Common.Gateways;
    using SkillNet.Application.Common;
    using SkillNet.Web.Services;
    using FluentValidation.AspNetCore;
    using Microsoft.OpenApi.Models;
    using Microsoft.Extensions.Configuration;


    public static class WebConfiguration
    {
        public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddWebComponents(configuration)
                .AddSwagger(configuration);


        private static IServiceCollection AddWebComponents(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddMvc(o =>
                {
                    o.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                        .Build()));
                })
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkillNet API", Version = "v1" });
            });
            return services;
        }
    }
}
