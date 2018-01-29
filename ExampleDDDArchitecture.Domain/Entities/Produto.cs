using System;

namespace ExampleDDDArchitecture.Domain.Entities
{
    public class Produto
    {
        //public int ProdutoId { get; set; }

        public string OrigemDDD { get; set; }

        public string DestinoDDD { get; set; }

        public decimal Tarifa { get; set; }

        public DateTime DataCadastro { get; set; }

        //public int CotacaoId { get; set; }

        //public virtual Cotacao Cotacao { get; set; }
    }
}
