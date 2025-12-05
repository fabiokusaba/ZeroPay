using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ZeroPay.Core.Entities;

namespace ZeroPay.Infrastructure;

public class ZeroPayDbContext(DbContextOptions<ZeroPayDbContext> options) : DbContext(options)
{
    public virtual DbSet<Carteira> Carteiras { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cofrinho> Cofrinhos { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Transacao> Transacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}