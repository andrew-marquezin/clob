using FluentValidation;

namespace Clob.Application.Features.Orders.Commands;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .WithMessage("O ID da conta é obrigatório.");

        RuleFor(x => x.PriceBtc)
            .GreaterThan(0)
            .WithMessage("O preço em BTC deve ser maior que zero.");

        RuleFor(x => x.PriceBrl)
            .GreaterThan(0)
            .WithMessage("O preço em BRL deve ser maior que zero.");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("O tipo de ordem fornecido é inválido.");
    }
}