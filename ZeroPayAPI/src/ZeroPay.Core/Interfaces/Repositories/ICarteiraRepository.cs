using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroPay.Core.Entities;

namespace ZeroPay.Core.Interfaces.Repositories;

public interface ICarteiraRepository
{
    Task<Guid> CadastrarAsync(Carteira carteira);
}
