using Microsoft.AspNetCore.Mvc;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.API.Controllers;

public class ClienteController(ICadastrarClienteApplication cadastrarClienteApplication) : MainController
{
    private readonly ICadastrarClienteApplication _cadastrarClienteApplication = cadastrarClienteApplication;
    
    [HttpPost]
    public async Task<IActionResult> CadastrarAsync([FromBody] ClienteInputModel inputModel)
    {
        var clienteId = await _cadastrarClienteApplication.CadastrarAsync(inputModel);
        
        return Ok(clienteId);
    }
}