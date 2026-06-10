using Clob.Application.Abstractions.Messaging;
using Clob.Domain.Abstractions;
using Clob.Domain.Entities;
using Clob.Domain.Enums;
using Clob.SharedKernel;

namespace Clob.Application.Features.Orders.Commands;

public sealed record CreateOrderCommand(Guid AccountId, decimal PriceBtc, decimal PriceBrl, OrderType Type)
    : ICommand<Guid>;

public sealed class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateOrderCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var order = new Order(Guid.NewGuid(), command.AccountId, command.Type, OrderStatus.Created,
            command.PriceBrl, command.PriceBtc);
        await orderRepository.AddAsync(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(order.Id);
    }
}
