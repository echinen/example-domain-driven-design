using ExampleDDDArchitecture.Application.Interface;
using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Services;

namespace ExampleDDDArchitecture.Application
{
    public class PlanoAppService : AppServiceBase<Plano>, IPlanoAppService
    {
        private readonly IPlanoService _planoService;

        public PlanoAppService(IPlanoService planoService)
            : base(planoService)
        {
            _planoService = planoService;
        }
    }
}
