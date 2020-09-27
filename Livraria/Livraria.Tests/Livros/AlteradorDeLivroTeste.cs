﻿using Bogus;
using Livraria.Common.Utils;
using Livraria.Domain.Dto;
using Livraria.Domain.Servicos.Alteradores;
using Livraria.Tests.Comum;
using Xunit;

namespace Livraria.Tests.Livros
{
    public class AlteradorDeLivroTeste
    {
        private readonly Faker _faker;
        private AlteradorDeLivro _alteradorDeLivro;

        public AlteradorDeLivroTeste()
        {
            _faker = FakerBuilder.Novo().Build();
            _alteradorDeLivro = new AlteradorDeLivro();
        }

        [Fact]
        public void DeveAlterarOLivro()
        {
            //arrange
            var livro = LivroBuilder.Novo().Build();
            var dto = ObterDtoComAutorValido();

            //act
            _alteradorDeLivro.Alterar(livro, dto);

            //assert
            Assert.Equal(livro.Titulo, dto.Titulo);
            Assert.Equal(livro.AnoDePublicacao, dto.AnoDePublicacao);
            Assert.Equal(livro.Edicao, dto.Edicao);
            Assert.Equal(livro.AutorId, dto.AutorId);
        }

        private LivroDto ObterDtoComAutorValido()
        {
            return new LivroDto()
            {
                AnoDePublicacao = _faker.Random.Int(Constantes.MilNovecentosENoventa, Constantes.DoisMilEVinte),
                AutorId = Constantes.Um,
                Edicao = _faker.Random.Int(Constantes.Um, Constantes.Dez),
                Id = _faker.Random.Int(Constantes.Um, Constantes.Cem),
                Titulo = _faker.Lorem.Paragraph()
            };
        }

    }
}
