using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Repositories;
using ExampleDDDArchitecture.Domain.Interfaces.Services;

namespace ExampleDDDArchitecture.Domain.Services
{
    public class PlanoService : ServiceBase<Plano>, IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoService(IPlanoRepository planoRepository)
            : base(planoRepository)
        {
            _planoRepository = planoRepository;
        }
    }
}
