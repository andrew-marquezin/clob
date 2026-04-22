using LegendaryBroccoli.Application.Abstractions.Persistence;
using LegendaryBroccoli.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace LegendaryBroccoli.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
        return services;
    }
}
