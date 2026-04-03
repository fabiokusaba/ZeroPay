using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Infrastructure.Repositories;

namespace ZeroPay.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ZeroPayDbContext>(p => 
            p.UseNpgsql("Server=localhost;Port=5490;Database=zeropay;User Id=admin;Password=admin;"));

        services.AddScoped<IClienteRepository, ClienteRepositoryImpl>();
        services.AddScoped<ICarteiraRepository, CarteiraRepositoryImpl>();
        services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();
        
        return  services;
    }
}