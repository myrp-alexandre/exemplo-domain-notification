using Livraria.Common.Handler;
using Livraria.Common.Implementation;

namespace Livraria.Tests.Comum
{
    public class NotifyBuilder
    {
        private NotifiyHandler _notifiyHandler;

        public static NotifyBuilder Novo()
        {
            return new NotifyBuilder
            {
                _notifiyHandler = new NotifiyHandler()
            };
        }

        public Notify Build()
        {
            return new Notify(_notifiyHandler);
        }
    }
}
