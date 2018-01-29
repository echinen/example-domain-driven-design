using ExampleDDDArchitecture.Domain.Entities;

namespace ExampleDDDArchitecture.Application.Interface
{
    public interface ICotacaoAppService : IAppServiceBase<Cotacao>
    {
        Cotacao ToDoQuotation(string origemDDD, string destinoDDD, int plano, int tempo);

        decimal CheckIfTariffExist(string origemDDD, string destinoDDD);

        Plano FindPlan(int id);
    }
}
