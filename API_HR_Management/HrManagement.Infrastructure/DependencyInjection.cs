using HrManagement.Application.Data;
using HrManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HrManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {

            //use SQLite for now , just for simplicity 
            services.AddDbContext<ApplicationDbContext>(ops =>
            ops.UseSqlite(config.GetConnectionString("Database")).EnableSensitiveDataLogging());

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }

    }
}
