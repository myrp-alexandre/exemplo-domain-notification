using Livraria.Common.Interfaces.Notifications;
using Livraria.Common.Notifications;
using Livraria.Domain.Interfaces.Removedores;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Domain.Interfaces.Validadores;
using System.Threading.Tasks;

namespace Livraria.Domain.Servicos.Removedores
{
    public class RemovedorDeLivro : IRemovedorDeLivro
    {
        //private readonly Notify _notify;
        private readonly IDomainNotificationHandler<DomainNotification> _notificacaoDeDominio;
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IValidadorDelivro _validadorDelivro;

        public RemovedorDeLivro(
          //  INotify notify,
          IDomainNotificationHandler<DomainNotification> notificacaoDeDominio,
            ILivroRepositorio livroRepositorio,
            IValidadorDelivro validadorDelivro
            )
        {
            //  _notify = notify.Invoke();
            _notificacaoDeDominio = notificacaoDeDominio;
            _livroRepositorio = livroRepositorio;
            _validadorDelivro = validadorDelivro;
        }
        public async Task Remover(int id)
        {
            var livro = await _livroRepositorio.ObterPorIdAsync(id);
            _validadorDelivro.ValidarLivroEncontrado(livro);

            if (!_notificacaoDeDominio.HasNotifications())
                _livroRepositorio.Remover(livro);
            //{
            //    _livroRepositorio.Remover(livro);
            //}
        }
    }
}
