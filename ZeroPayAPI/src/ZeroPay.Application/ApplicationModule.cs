using Microsoft.Extensions.DependencyInjection;
using ZeroPay.Application.Applications;
using ZeroPay.Application.Notifications;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Notifications;

namespace ZeroPay.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<ICadastrarClienteApplication, CadastrarClienteApplication>();
        services.AddScoped<IBuscarClientesApplication, BuscarClientesApplication>();
        services.AddScoped<IBuscarClientePorIdApplication, BuscarClientePorIdApplication>();
        services.AddScoped<IAtualizarClienteApplication, AtualizarClienteApplication>();
        services.AddScoped<IDepositarApplication, DepositarApplication>();
        services.AddScoped<INotificacao, Notificacao>();
        
        return services;
    }
}