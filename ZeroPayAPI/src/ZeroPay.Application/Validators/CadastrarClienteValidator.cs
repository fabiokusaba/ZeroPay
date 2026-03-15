using FluentValidation;
using ZeroPay.Core.Models.InputModels;
using ZeroPay.Shared.Utils;

namespace ZeroPay.Application.Validators;

public class CadastrarClienteValidator : BaseClienteValidator<ClienteInputModel>
{
    public CadastrarClienteValidator()
    {
        RuleFor(c => c.Cpf)
            .NotEmpty()
            .WithMessage("O CPF do cliente deve ser informado")
            .Must(Validations.IsCpf)
            .WithMessage("O CPF informado é inválido");
        
        RuleFor(c => c.Senha)
            .NotEmpty()
            .WithMessage("A senha do cliente deve ser informado");

        RuleFor(c => c.DataNascimento)
            .NotEmpty()
            .WithMessage("A data de nascimento do cliente deve ser informado");
    }
}