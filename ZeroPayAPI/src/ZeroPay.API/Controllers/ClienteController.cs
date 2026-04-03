using Microsoft.AspNetCore.Mvc;
using ZeroPay.Application.Applications;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Notifications;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.API.Controllers;

public class ClienteController(
    ICadastrarClienteApplication cadastrarClienteApplication,
    IBuscarClientesApplication buscarClientesApplication,
    IBuscarClientePorIdApplication buscarClientePorIdApplication,
    IAtualizarClienteApplication atualizarClienteApplication,
    INotificacao notificacao
) : MainController(notificacao)
{
    [HttpPost]
    public async Task<IActionResult> CadastrarAsync([FromBody] ClienteInputModel inputModel)
    {
        var clienteId = await cadastrarClienteApplication.CadastrarAsync(inputModel);
        
        return RespostaPersonalizada(Ok(clienteId));
    }

    [HttpGet]
    public async Task<IActionResult> BuscarAsync()
    {
        var clientes = await buscarClientesApplication.BuscarAsync();
        return RespostaPersonalizada(Ok(clientes));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorIdAsync([FromRoute] Guid id)
    {
        var cliente = await buscarClientePorIdApplication.BuscarPorIdAsync(id);

        if (cliente is null)
        {
            return NotFound();
        }

        return RespostaPersonalizada(Ok(cliente));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarAsync([FromRoute] Guid id, [FromBody] AtualizacaoClienteInputModel inputModel)
    {
        await atualizarClienteApplication.AtualizarAsync(id, inputModel);
        return RespostaPersonalizada(NoContent());
    }
}