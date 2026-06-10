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

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ClobDbContext>());

        services.Scan(scan => scan
            .FromAssemblyOf<InfrastructureAssemblyMarker>()
            // Automatically scan all classes ending with "Repository"
            // If it's an InMemory repository, register as Singleton
            .AddClasses(classes =>
                classes.Where(type => type.Name.EndsWith("Repository") && type.Name.Contains("InMemory")))
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
            // Otherwise, register as Scoped (for EF Core repositories)
            .AddClasses(classes =>
                classes.Where(type => type.Name.EndsWith("Repository") && !type.Name.Contains("InMemory")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}

internal sealed class InfrastructureAssemblyMarker;
