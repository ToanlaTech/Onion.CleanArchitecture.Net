using Onion.CleanArchitecture.Net.Application;
using Onion.CleanArchitecture.Net.Application.Interfaces;
using Onion.CleanArchitecture.Net.Infrastructure.Identity;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence;
using Onion.CleanArchitecture.Net.Infrastructure.Shared;
using Onion.CleanArchitecture.Net.WebApp.Server.Extensions;
using Onion.CleanArchitecture.Net.WebApp.Server.Initializer;
using Onion.CleanArchitecture.Net.WebApp.Server.Services;
var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;
var _services = builder.Services;
var _env = builder.Environment;
// Add services to the container.

_services.AddEnvironmentVariablesExtension();
_services.ConfigureServicesExtension();
_services.AddIdentityLayer();
_services.AddApplicationLayer();
_services.AddNpgSqlIdentityInfrastructure(typeof(Program).Assembly.FullName);
_services.AddIdentityRepositories(_config);
_services.AddNpgSqlPersistenceInfrastructure(typeof(Program).Assembly.FullName);
_services.AddPersistenceRepositories();
_services.AddSharedInfrastructure(_config);
if (_env.IsDevelopment())
{
    _services.AddSwaggerExtension();
}

_services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
_services.AddApiVersioningExtension();
_services.AddHealthChecks();
_services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initializer = new ApplicationInitializer(scope.ServiceProvider);
    await initializer.InitializeAsync();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (_env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerExtension();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();

// app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
