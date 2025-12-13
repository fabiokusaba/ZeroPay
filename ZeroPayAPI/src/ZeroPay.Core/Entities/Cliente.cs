using ZeroPay.Core.Enums;

namespace ZeroPay.Core.Entities;

public class Cliente
{
    public Guid Id { get; set; }

    public string NomeCompleto { get; set; } = null!;

    public ESituacaoCliente Situacao { get; set; }

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string Telefone { get; set; } = null!;

    public string Senha { get; set; } = null!;
}
