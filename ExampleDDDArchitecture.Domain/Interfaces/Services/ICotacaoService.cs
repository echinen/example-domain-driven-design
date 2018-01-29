using ExampleDDDArchitecture.Domain.Entities;

namespace ExampleDDDArchitecture.Domain.Interfaces.Services
{
    public interface ICotacaoService : IServiceBase<Cotacao>
    {
        Cotacao ToDoQuotation(string origemDDD, string destinoDDD, int plano, int tempo);

        decimal CheckIfTariffExist(string origemDDD, string destinoDDD);

        Plano FindPlan(int id);
    }
}
