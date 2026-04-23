using LegendaryBroccoli.SharedKernel;

namespace LegendaryBroccoli.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken = default);
}
