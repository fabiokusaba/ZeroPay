using ZeroPay.Core;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.API.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    private const string MENSAGEM_PADRAO = "Tivemos um problema interno no servidor. Tente novamente mais tarde!";
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            // Cada requisição/controller no C# é um middleware, então ele vai receber a requisição e aguardar com o 'await' o próximo
            // middleware executar, que no caso vai ser o nosso controller, e o 'context' guarda todas as informações da nossa requisição
            // que acabamos de receber e vamos estar passando ela para o próximo middleware.
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        var mensagemErro = Variaveis.Geral.ENV == "dev" ? (ex.InnerException?.Message ?? ex.Message ?? MENSAGEM_PADRAO) : MENSAGEM_PADRAO;

        if (context is not null)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(new RespostaPadraoViewModel([mensagemErro]));
        }
    }
}