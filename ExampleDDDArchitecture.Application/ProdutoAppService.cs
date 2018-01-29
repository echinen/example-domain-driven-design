using ExampleDDDArchitecture.Application.Interface;
using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Services;

namespace ExampleDDDArchitecture.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }


    }
}
