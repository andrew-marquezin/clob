using Clob.Domain.Abstractions;
using Clob.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Clob.Infrastructure;

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

