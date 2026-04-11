using ZeroPay.API.Extensions;
using ZeroPay.API.Middlewares;
using ZeroPay.Application;
using ZeroPay.Core;
using ZeroPay.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddDomain()
    .AddInfrastructure()
    .AddAplication()
    .AddValidators()
    .AddMiddlewares(); // Adicionando o middleware no contexto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "API Profissional - V1";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Profissional - V1");
    });
}

// Ordem lógica -> Redirecionamento HTTPS -> Validação do usuário logado -> Tratamento global de exceção -> Requisição
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>(); // Indicando que vamos usar o nosso middleware

app.MapControllers();

app.Run();