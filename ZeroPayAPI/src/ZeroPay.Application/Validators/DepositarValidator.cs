using FluentValidation;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Validators;

public class DepositarValidator : AbstractValidator<DepositoInputModel>
{
    public DepositarValidator()
    {
        RuleFor(d => d.Valor)
            .NotNull()
            .WithMessage("O valor para depósito não pode ser nulo")
            .NotEmpty()
            .WithMessage("Informe um valor para depósito")
            .GreaterThan(0)
            .WithMessage("O valor mínimo para depósito precisa ser superior a zero");

        RuleFor(p => p.CarteiraId)
            .NotNull()
            .WithMessage("O id da carteira não pode ser nulo")
            .NotEmpty()
            .WithMessage("Informe o id da carteira para depósito");
    }
}