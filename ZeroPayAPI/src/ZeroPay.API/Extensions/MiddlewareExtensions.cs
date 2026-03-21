using ZeroPay.API.Middlewares;

namespace ZeroPay.API.Extensions;

public static class MiddlewareExtensions
{
    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        // Aqui na nossa injeção de dependência nós vamos dizer que ele vai ter uma nova instância a cada requisição
        // que chegar, pois como o nosso 'GlobalExceptionHandler' é um serviço leve podemos fazer isso
        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }
}