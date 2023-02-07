using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StateManagements.Models.Data;

namespace StateManagements.Models;

public static class GlobalConfiguration
{
    public static IServiceCollection ModelsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
         
        services.AddDbContext<StateManagementsContext>(option => option
            .UseSqlServer(configuration
                .GetConnectionString("default"), builder => builder.MigrationsAssembly(typeof(StateManagementsContext).Assembly.FullName)));

        return services;
    }
}

