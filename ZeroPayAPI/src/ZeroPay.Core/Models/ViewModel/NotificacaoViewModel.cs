using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ZeroPay.Core.Models.ViewModel;

public class NotificacaoViewModel(string mensagem, HttpStatusCode statusCode)
{
    public string Mensagem { get; } = mensagem;
    public HttpStatusCode StatusCode { get; } = statusCode;
}
