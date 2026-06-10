using Clob.Application.Abstractions.Messaging;
using Clob.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Clob.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ApplicationAssemblyMarker>()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsSelfWithInterfaces()
            .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}

internal sealed class ApplicationAssemblyMarker;
