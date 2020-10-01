using Livraria.Common.Interfaces.Notifications;
using Livraria.Common.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Livraria.API.Controllers
{
    public abstract class BaseController : Controller
    {
        // private readonly NotifiyHandler _messageHandler;
        private readonly IDomainNotificationHandler<DomainNotification> _notificacaoDeDominio;

        protected BaseController(IDomainNotificationHandler<DomainNotification> notificacaoDeDominio)
          //  INotificationHandler<Notifications> notification)
        {
            //  _messageHandler = (NotifiyHandler)notification;
            _notificacaoDeDominio = notificacaoDeDominio;
        }

        protected bool HasNotifications()
        {
            return _notificacaoDeDominio.HasNotifications();
        }

        protected bool OperacaoValida() => !_notificacaoDeDominio.HasNotifications();

        protected BadRequestObjectResult BadRequestResponse()
        {
            return BadRequest(_notificacaoDeDominio.GetNotifications().Select(x => x.Value));
        }
    }
}
