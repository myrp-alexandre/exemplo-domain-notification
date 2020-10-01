using FluentValidation.Results;
using Livraria.Common.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Common.Interfaces.Notifications
{
    public interface IDomainNotificationHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
        void ClearNotifications();
        Task Handle(T message);
        Task NotificarValidacao(ValidationResult validationResult);
        Task NotificarValidacao(string mensagem);
    }
}
