using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Repositories;
using ExampleDDDArchitecture.Domain.Interfaces.Services;

namespace ExampleDDDArchitecture.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
    }
}
