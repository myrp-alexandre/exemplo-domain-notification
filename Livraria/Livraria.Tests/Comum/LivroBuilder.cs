using Livraria.Common.Utils;
using Livraria.Domain.Entidades;

namespace Livraria.Tests.Comum
{
    public class LivroBuilder
    {
        private int _id;
        private string _titulo;
        private int _anoDePublicacao;
        private int _edicao;
        private int _autorId;

        public static LivroBuilder Novo()
        {
            var faker = FakerBuilder.Novo().Build();
            return new LivroBuilder
            {
                _id = faker.Random.Int(Constantes.Um, Constantes.Cem),
                _titulo = faker.Random.Words(),
                _anoDePublicacao = faker.Random.Int(Constantes.MilNovecentosENoventa, Constantes.DoisMilEVinte),
                _edicao = faker.Random.Int(Constantes.Um, Constantes.Dez),
                _autorId = faker.Random.Int(Constantes.Um, Constantes.Cem)
            };
        }

        public LivroBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public LivroBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;
            return this;
        }

        public LivroBuilder ComAnoDePublicacao(int anoPublicacao)
        {
            _anoDePublicacao = anoPublicacao;
            return this;
        }
        public LivroBuilder ComEdicao(int edicao)
        {
            _edicao = edicao;
            return this;
        }
        public LivroBuilder ComAutorId(int autorId)
        {
            _autorId = autorId;
            return this;
        }

        public Livro Build()
        {
            var livro = new Livro(_titulo, _anoDePublicacao, _edicao, _autorId);
            if (_id > Constantes.Zero)
                livro.DefinirId(_id);
            return livro;
        }

    }
}
