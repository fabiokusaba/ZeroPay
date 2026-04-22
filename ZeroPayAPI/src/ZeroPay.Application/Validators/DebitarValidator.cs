using FluentValidation;
using ZeroPay.Core.Enums;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Validators;

public class DebitarValidator : AbstractValidator<DebitoInputModel>
{
    public DebitarValidator()
    {
        RuleFor(d => d.Tipo)
            .NotNull()
            .WithMessage("O tipo do débito deve ser informado")
            .Must(tipo => tipo == ETipoTransacao.Saque || tipo == ETipoTransacao.Transferencia)
            .WithMessage("O tipo de débito deve ser Saque ou Transferência");

        RuleFor(d => d.Valor)
            .NotNull()
            .WithMessage("O valor para débito não pode ser nulo")
            .NotEmpty()
            .WithMessage("Informe um valor para débito");

        RuleFor(d => d.CarteiraId)
            .NotNull()
            .WithMessage("O id da carteira não pode ser nulo")
            .NotEmpty()
            .WithMessage("Informe o id da carteira de débito");
    }
}