using ExampleDDDArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace ExampleDDDArchitecture.Domain.Interfaces.Repositories
{
    public interface ICotacaoRepository : IRepositoryBase<Cotacao>
    {
        //Adicionar alguma regra de negócio especifica
        //Cotacao ToDoQuotation(Cotacao cotacao);

        decimal CheckIfTariffExist(string origemDDD, string destinoDDD);

        Plano FindPlan(int id);
}
}
