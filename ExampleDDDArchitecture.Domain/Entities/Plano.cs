using System;
using System.Collections.Generic;

namespace ExampleDDDArchitecture.Domain.Entities
{
    public class Plano
    {
        public int PlanoId { get; set; }

        public string TipoPlano { get; set; }

        public DateTime DataCadastro { get; set; }

        //public int CotacaoId { get; set; }

        //public virtual Cotacao Cotacao { get; set; }
    }
}
