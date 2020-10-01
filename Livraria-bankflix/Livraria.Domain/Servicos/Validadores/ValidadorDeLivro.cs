using Livraria.Common.Interfaces.Notifications;
using Livraria.Common.Notifications;
using Livraria.Common.Utils;
using Livraria.Domain.Dto;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Validadores;

namespace Livraria.Domain.Servicos.Validadores
{
    public class ValidadorDeLivro : IValidadorDelivro
    {
        // private readonly Notify _notify;
        private readonly IDomainNotificationHandler<DomainNotification> _notificacaoDeDominio;

        public ValidadorDeLivro(IDomainNotificationHandler<DomainNotification> notificacaoDeDominio)//INotify notify)
        {
            // _notify = notify.Invoke();
            _notificacaoDeDominio = notificacaoDeDominio;
        }

        public void Validar(LivroDto dto)
        {
            if (dto == null)
            {
                // _notify.NewNotification(Resources.LivroEntidade, Resources.LivroNulo);
                _notificacaoDeDominio.NotificarValidacao(Resources.LivroNulo);
            }
            else if (dto.Autor == null && dto.AutorId < Constantes.Um)
            {
                // _notify.NewNotification(Resources.LivroEntidade, Resources.LivroComAutorNulo);
                _notificacaoDeDominio.NotificarValidacao(Resources.LivroComAutorNulo);
            }
        }

        public void ValidarLivroEncontrado(Livro livro)
        {
            if (livro == null)
                _notificacaoDeDominio.NotificarValidacao(Resources.LivroNaoEncontrado);
            //  _notify.NewNotification(Resources.LivroEntidade, Resources.LivroNaoEncontrado);
        }

        public void ValidarSeLivroExiste(Livro livro)
        {
            if (livro != null)
                _notificacaoDeDominio.NotificarValidacao(Resources.LivroJaExiste);
            //  _notify.NewNotification(Resources.LivroEntidade, Resources.LivroJaExiste);
        }
    }
}
