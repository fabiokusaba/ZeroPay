using ZeroPay.Core.Entities;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Applications;

public class CadastrarClienteApplication(IClienteRepository repository) : ICadastrarClienteApplication
{
    private readonly IClienteRepository _repository = repository;
    
    public async Task<Guid> CadastrarAsync(ClienteInputModel inputModel)
    {
        var cliente = new Cliente(
            inputModel.NomeCompleto, 
            inputModel.Email, 
            inputModel.Cpf, 
            inputModel.DataNascimento, 
            inputModel.Telefone, 
            inputModel.Senha
        );
        
        return await _repository.CadastrarAsync(cliente);
    }
}