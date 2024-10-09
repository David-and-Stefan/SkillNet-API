using Microsoft.Extensions.Configuration;
using SkillNet.Application;
using SkillNet.Application.Common.Settings;
using SkillNet.Domain;
using SkillNet.Infrastructure;
using SkillNet.Web;
using SkillNet.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddWeb(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
    });
}

app.UseValidationExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(opts =>
{
    opts.AllowAnyOrigin();
    opts.AllowAnyHeader();
    opts.AllowAnyMethod();
});
app.UseAuthorization();
app.MapControllers();

app.Run();
