using Livraria.Data.Repository;
using Livraria.Domain.Interfaces.Alteradores;
using Livraria.Domain.Interfaces.Armazenadores;
using Livraria.Domain.Interfaces.Removedores;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Domain.Interfaces.Validadores;
using Livraria.Domain.Servicos.Alteradores;
using Livraria.Domain.Servicos.Armazenadores;
using Livraria.Domain.Servicos.Removedores;
using Livraria.Domain.Servicos.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IArmazenadorDeLivro), typeof(ArmazenadorDeLivro));
            services.AddScoped(typeof(ILivroRepositorio), typeof(LivroRepositorio));
            services.AddScoped(typeof(IAutorRepositorio), typeof(AutorRepositorio));
            services.AddScoped(typeof(IValidadorDelivro), typeof(ValidadorDeLivro));
            services.AddScoped(typeof(IAlteradorDeLivro), typeof(AlteradorDeLivro));
            services.AddScoped(typeof(IRemovedorDeLivro), typeof(RemovedorDeLivro));
        }
    }
}
