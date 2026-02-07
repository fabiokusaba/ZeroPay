using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using ZeroPay.Application.Validators;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.API.Extensions;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(c =>
        {
            c.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });

        services.AddValidatorsFromAssemblyContaining<CadastrarClienteValidator>();
        
        return services;
    }
    
    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public Task<IActionResult?> CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails,
            IDictionary<IValidationContext, ValidationResult> validationResults)
        {
            return Task.FromResult<IActionResult?>(new BadRequestObjectResult(
                new RespostaPadraoViewModel(
                    context
                        .ModelState.SelectMany(ms => ms.Value?.Errors ?? [])
                        .Select(e => e.ErrorMessage)
                )
            ));
        }
    }
}