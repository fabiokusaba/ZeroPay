using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ZeroPay.Core.Interfaces.Notifications;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Application.Notifications;

public class Notificacao : INotificacao
{
    private readonly List<NotificacaoViewModel> _notificacoes;

    public Notificacao()
    {
        _notificacoes = [];
    }

    public void Handle(string mensagem, HttpStatusCode statusCode)
    {
        var notificacao = new NotificacaoViewModel(mensagem, statusCode);
        _notificacoes.Add(notificacao);
    }

    public void LimparNotificacoes()
    {
        if (TemNotificacoes())
            _notificacoes.Clear();
    }

    public List<NotificacaoViewModel> ObterNotificacoes()
    {
        return _notificacoes;
    }

    public bool TemNotificacoes()
    {
        return _notificacoes.Count > 0;
    }
}
