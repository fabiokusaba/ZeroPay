using Microsoft.Extensions.DependencyInjection;
using ZeroPay.Core.Interfaces.Services;
using ZeroPay.Core.Services;

namespace ZeroPay.Core;

public static class DomainModule
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IRegistrarTransacaoService, RegistrarTransacaoServiceImpl>();

        return services;
    }
}