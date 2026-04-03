using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Core.Interfaces.Notifications;

public interface INotificacao
{
    void LimparNotificacoes();
    bool TemNotificacoes();
    List<NotificacaoViewModel> ObterNotificacoes();
    void Handle(string mensagem, HttpStatusCode statusCode);
}
