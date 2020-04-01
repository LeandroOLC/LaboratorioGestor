using LaboratorioGestor.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
