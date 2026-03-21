namespace ZeroPay.Core;

public static class Variaveis
{
    public static class Geral
    {
        // Vamos pegar a variável que está 'ASPNETCORE_ENVIRONMENT' que está dentro do nosso arquivo 'launchSettings.json' e caso ela
        // não exista vamos lançar uma exception
        public static string ENV = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
                                   ?? throw new ArgumentNullException("O ambiente deve ser informado");
    }
}