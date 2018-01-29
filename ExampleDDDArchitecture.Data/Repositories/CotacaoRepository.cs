using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Repositories;
using ExampleDDDArchitecture.Infra.Data.Context;
using System.Collections.Generic;

namespace ExampleDDDArchitecture.Infra.Data.Repositories
{
    public class CotacaoRepository : RepositoryBase<Cotacao>, ICotacaoRepository
    {
        public decimal CheckIfTariffExist(string origemDDD, string destinoDDD)
        {
            var produto = ctx.Produtos.Find(origemDDD, destinoDDD);

            return produto != null ? produto.Tarifa : 0;
        }

        public Plano FindPlan(int id)
        {
            return ctx.Planos.Find(id);
        }
    }
}
