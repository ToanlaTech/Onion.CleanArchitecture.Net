﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Contexts;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Models;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Contexts;
using Serilog;

namespace Onion.CleanArchitecture.Net.WebApp.Server.Initializer
{
    public class ApplicationInitializer
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task InitializeAsync()
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            try
            {
                var identityDbContext = _serviceProvider.GetRequiredService<IdentityContext>();
                identityDbContext.Database.Migrate();
                var dbContext = _serviceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
                Log.Information("Finished Seeding Default Data");
                Log.Information("Application Starting");
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "An error occurred seeding the DB");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
