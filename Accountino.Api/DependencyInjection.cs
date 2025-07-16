using Accountino.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Accountino.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // ТODO: Register Application layer services

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Register Infrastructure layer services
        services.AddDbContext<AccountinoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        return services;
    }
}
