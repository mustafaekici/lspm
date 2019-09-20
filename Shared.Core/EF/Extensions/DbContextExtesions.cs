using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF.Extensions
{
    public static class DbContextExtesions
    {
        public static void CreateDatabase<T>(this IApplicationBuilder app, IConfiguration configuration, bool isMigrate) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<T>() as T;
                var seed = serviceScope.ServiceProvider.GetService<IDataSeeder<T>>();
                var ignoreSeed = configuration.GetValue<bool>("SeedData:IgnoreSeed");
                var ignoreSeedSample = configuration.GetValue<bool>("SeedData:IgnoreSampleSeed");

                if (isMigrate)
                    db?.Database.Migrate();

                if (!ignoreSeed)
                    seed.Seed(db);

                if (!ignoreSeedSample)
                    seed.SeedSample(db);
            }
        }
    }
}
