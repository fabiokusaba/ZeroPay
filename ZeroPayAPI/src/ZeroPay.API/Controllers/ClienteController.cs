using Microsoft.AspNetCore.Mvc;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.API.Controllers;

public class ClienteController(
    ICadastrarClienteApplication cadastrarClienteApplication,
    IBuscarClientesApplication buscarClientesApplication,
    IBuscarClientePorIdApplication buscarClientePorIdApplication
) : MainController
{
    [HttpPost]
    public async Task<IActionResult> CadastrarAsync([FromBody] ClienteInputModel inputModel)
    {
        var clienteId = await cadastrarClienteApplication.CadastrarAsync(inputModel);
        
        return Ok(clienteId);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarAsync()
    {
        var clientes = await buscarClientesApplication.BuscarAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorIdAsync([FromRoute] Guid id)
    {
        var cliente = await buscarClientePorIdApplication.BuscarPorIdAsync(id);

        if (cliente is null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }
}