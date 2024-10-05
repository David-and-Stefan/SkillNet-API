using SkillNet.Application;
using SkillNet.Domain;
using SkillNet.Infrastructure;
using SkillNet.Web;
using SkillNet.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerGen()
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddWebComponents();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseValidationExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseIdentityServer();
app.UseCors(opts =>
{
    opts.AllowAnyOrigin();
    opts.AllowAnyHeader();
    opts.AllowAnyMethod();
});
app.UseAuthorization();
app.MapControllers();

app.Run();
