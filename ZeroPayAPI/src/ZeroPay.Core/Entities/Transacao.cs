using ZeroPay.Core.Enums;

namespace ZeroPay.Core.Entities;

public class Transacao(ETipoTransacao tipo, decimal valor, string? descricao, Guid carteiraId, decimal saldoResultante, Guid? cofrinhoId = null)
{
    public Guid Id { get; } = Guid.NewGuid();

    public short Tipo { get; } = (short) tipo;

    public DateTime Data { get; } = DateTime.Now;

    public decimal Valor { get; } = valor;

    public decimal SaldoResultante { get; } = saldoResultante;

    public string? Descricao { get; } = descricao;

    public Guid CarteiraId { get; } = carteiraId;

    public Guid? CofrinhoId { get; } = cofrinhoId;
}
