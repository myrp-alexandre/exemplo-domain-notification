using Bogus;
using Livraria.Common.Handler;
using Livraria.Common.Implementation;
using Livraria.Common.Utils;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Domain.Interfaces.Validadores;
using Livraria.Domain.Servicos.Removedores;
using Livraria.Tests.Comum;
using Moq;
using Xunit;

namespace Livraria.Tests.Livros
{
    public class RemovedorDeLivroTeste
    {
        private Notify _notify;
        private readonly Faker _faker;
        private readonly Mock<ILivroRepositorio> _livroRepositorioMock;
        private readonly Mock<IValidadorDelivro> _validadorDeLivroMock;

        private RemovedorDeLivro _removedorDeLivro;

        public RemovedorDeLivroTeste()
        {
            _notify = NotifyBuilder.Novo().Build();
            _faker = FakerBuilder.Novo().Build();
            _livroRepositorioMock = new Mock<ILivroRepositorio>();
            _validadorDeLivroMock = new Mock<IValidadorDelivro>();
            _removedorDeLivro = new RemovedorDeLivro(_notify, _livroRepositorioMock.Object, _validadorDeLivroMock.Object);
        }

        [Fact]
        public void DeveRemoverLivro()
        {
            //arrange
            var livro = LivroBuilder.Novo().Build();
            _livroRepositorioMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(livro);
 
            //act
            _removedorDeLivro.Remover(livro.Id);

            //assert
            _livroRepositorioMock.Verify(x => x.Remover(It.IsAny<Livro>()), Times.Once);
        }

        [Fact]
        public void NaoDeveRemoverLivro()
        {
            //arrange
            CriaSetUpRepositorioLivroObterPorIdAsync();
            CriaSetUpValidadorDeLivroValidarLivroEncontrado();
            _removedorDeLivro = new RemovedorDeLivro(_notify, _livroRepositorioMock.Object, _validadorDeLivroMock.Object);

            //act
            _removedorDeLivro.Remover(Constantes.Um);

            //assert
            _livroRepositorioMock.Verify(x => x.Remover(It.IsAny<Livro>()), Times.Never);
        }
        private void CriaSetUpValidadorDeLivroValidarLivroEncontrado()
        {
            _validadorDeLivroMock.Setup(x => x.ValidarLivroEncontrado(It.IsAny<Livro>()))
           .Callback(() =>
           {
               _notify.Invoke().NewNotification(Resources.LivroEntidade, Resources.LivroNaoEncontrado);
           });
        }

        private void CriaSetUpRepositorioLivroObterPorIdAsync()
        {
            Livro livro = null;
            _livroRepositorioMock.Setup(x => x.ObterPorIdAsync(Constantes.Um)).ReturnsAsync(livro);
        }

    }
}
