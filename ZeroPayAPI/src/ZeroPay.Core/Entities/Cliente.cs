using ZeroPay.Core.Enums;

namespace ZeroPay.Core.Entities;

public class Cliente
{
    public Cliente(string nomeCompleto, string email, string cpf, DateOnly dataNascimento, string telefone, string senha)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto;
        Situacao = ESituacaoCliente.Ativo;
        Email = email;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        Senha = senha;
    }

    public Guid Id { get; private set; }

    public string NomeCompleto { get; private set; }

    public ESituacaoCliente Situacao { get; private set; }

    public string Email { get; private set; } 

    public string Cpf { get; private set; } 

    public DateOnly DataNascimento { get; private set; }

    public string Telefone { get; private set; } 

    public string Senha { get; private set; }

    public Cliente SetNomeCompleto(string nomeCompleto)
    {
        NomeCompleto = nomeCompleto;
        return this;
    }

    public Cliente SetEmail(string email)
    {
        Email = email;
        return this;
    }

    public Cliente SetTelefone(string telefone)
    {
        Telefone = telefone;
        return this;
    }
}
