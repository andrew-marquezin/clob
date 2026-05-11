using Clob.Domain.Abstractions;
using Clob.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clob.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClobDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));

        services.Scan(scan => scan
            .FromAssemblyOf<InfrastructureAssemblyMarker>()
            .AddClasses(classes => classes.AssignableTo<ITodoRepository>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
            .AddClasses(classes => classes.AssignableTo<IAccountRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}

internal sealed class InfrastructureAssemblyMarker;
