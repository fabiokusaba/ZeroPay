namespace ZeroPay.Core.Models.InputModels;

public class AtualizacaoClienteInputModel(string nomeCompleto, string email, string telefone)
    : BaseClienteInputModel(nomeCompleto, email, telefone);