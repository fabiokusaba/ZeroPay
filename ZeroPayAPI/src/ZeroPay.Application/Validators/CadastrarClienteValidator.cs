using FluentValidation;
using ZeroPay.Core.Models.InputModels;
using ZeroPay.Shared.Utils;

namespace ZeroPay.Application.Validators;

public class CadastrarClienteValidator : AbstractValidator<ClienteInputModel>
{
    public CadastrarClienteValidator()
    {
        RuleFor(c => c.NomeCompleto)
            .NotEmpty()
            .WithMessage("O nome completo do cliente deve ser informado");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("O e-mail do cliente deve ser informado")
            .EmailAddress()
            .WithMessage("O e-mail informado é inválido");

        RuleFor(c => c.Cpf)
            .NotEmpty()
            .WithMessage("O CPF do cliente deve ser informado")
            .Must(Validations.IsCpf)
            .WithMessage("O CPF informado é inválido");

        RuleFor(c => c.Telefone)
            .NotEmpty()
            .WithMessage("O telefone do cliente deve ser informado")
            .MaximumLength(20)
            .WithMessage("O telefone do cliente deve conter no máximo 20 caracteres");
        
        RuleFor(c => c.Senha)
            .NotEmpty()
            .WithMessage("A senha do cliente deve ser informado");

        RuleFor(c => c.DataNascimento)
            .NotEmpty()
            .WithMessage("A data de nascimento do cliente deve ser informado");
    }
}