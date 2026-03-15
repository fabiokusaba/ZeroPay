using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Applications;

public class AtualizarClienteApplication(IClienteRepository clienteRepository) : IAtualizarClienteApplication
{
    public async Task AtualizarAsync(Guid id, AtualizacaoClienteInputModel inputModel)
    {
        var cliente = await clienteRepository.BuscarPorIdAsync(id);

        if (cliente is null)
        {
            throw new NullReferenceException("O cliente informado não foi encontrado na base");
        }

        cliente
            .SetNomeCompleto(inputModel.NomeCompleto)
            .SetTelefone(inputModel.Telefone)
            .SetEmail(inputModel.Email);

        await clienteRepository.SaveChangesAsync();
    }
}