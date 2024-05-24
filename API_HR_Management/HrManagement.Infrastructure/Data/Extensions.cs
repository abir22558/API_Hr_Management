using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HrManagement.Infrastructure.Data
{
       public static class Extensions
        {
            public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
            {
                //create database from migration automaticly when runing the app 
                using var scope = app.ApplicationServices.CreateScope();
                using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.MigrateAsync();

                return app;
            }
        }
}
