using FluentValidation.Results;
using Livraria.Common.Interfaces.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Common.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
        }

        public Task Handle(DomainNotification message)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public async Task NotificarValidacao(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
                await Handle(new DomainNotification(TipoDeNotificacao.NotificacaoDeDominio, erro.ErrorMessage));
        }

        public async Task NotificarValidacao(string mensagem)
        {
            await Handle(new DomainNotification(TipoDeNotificacao.NotificacaoDeDominio, mensagem));
        }
    }
}
