using LaboratorioGestor.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;
        private readonly IUser _user;

        public Guid ProteticoId { get; set; }

        protected BaseController(INotificador notificador, IUser user)
        {
            _notificador = notificador;
            _user = user;

            if (_user.IsAuthenticated())
            {
                ProteticoId = _user.GetUserId();
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
