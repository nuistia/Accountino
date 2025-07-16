using Accountino.Application.Interfaces;
using Accountino.Application.Mapping;
using Accountino.Application.Services;
using Accountino.Infrastructure.Persistence;
using Accountino.Infrastructure.Persistence.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Accountino.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IExpenseService, ExpenseService>();

        services.AddSingleton(provider =>
        {
            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }, loggerFactory);

            //config.AssertConfigurationIsValid();

            return config.CreateMapper();
        });

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AccountinoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
