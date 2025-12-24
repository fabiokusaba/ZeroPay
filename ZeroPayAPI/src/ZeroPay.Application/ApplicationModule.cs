using Microsoft.Extensions.DependencyInjection;
using ZeroPay.Application.Applications;
using ZeroPay.Core.Interfaces.Applications;

namespace ZeroPay.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<ICadastrarClienteApplication, CadastrarClienteApplication>();
        return services;
    }
}