namespace ZeroPay.Core.Entities;

public class Carteira
{
    public Carteira(Guid clienteId)
    {
        Id = Guid.NewGuid();
        Saldo = 0;
        Conta = GerarNumeroConta();
        Agencia = "0001";
        ClienteId = clienteId;
    }

    public Guid Id { get; set; }

    public decimal Saldo { get; set; }

    public string Conta { get; set; } = null!;

    public string Agencia { get; set; } = null!;

    public Guid ClienteId { get; set; }

    private static string GerarNumeroConta()
    {
        var random = new Random();
        int numeroConta = random.Next(10000000, 99999999);
        int digito = random.Next(0, 10);

        return $"{numeroConta}-{digito}";
    }

    public void AtualizarSaldo(decimal novoSaldo)
    {
        Saldo = novoSaldo;
    }
}
