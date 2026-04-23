using LegendaryBroccoli.Domain.Abstractions;
using LegendaryBroccoli.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace LegendaryBroccoli.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<InfrastructureAssemblyMarker>()
            .AddClasses(classes => classes.AssignableTo(typeof(ITodoRepository)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

        return services;
    }
}

internal sealed class InfrastructureAssemblyMarker;

