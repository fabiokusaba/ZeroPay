using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Core.Interfaces.Applications;

public interface IDebitarApplication
{
    Task<decimal> DebitarAsync(DebitoInputModel inputModel);
}