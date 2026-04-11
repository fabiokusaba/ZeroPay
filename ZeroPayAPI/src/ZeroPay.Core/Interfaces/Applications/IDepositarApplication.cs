using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Core.Interfaces.Applications;

public interface IDepositarApplication
{
    Task<decimal> DepositarAsync(DepositoInputModel inputModel);
}