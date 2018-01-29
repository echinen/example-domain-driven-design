using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Repositories;

namespace ExampleDDDArchitecture.Infra.Data.Repositories
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
    }
}
