using System;
using System.Collections.Generic;

namespace ExampleDDDArchitecture.Domain.Entities
{
    public class Cotacao
    {
        public int CotacaoId { get; set; }

        public int TempoLigacao { get; set; }

        public decimal ComFaleMais { get; set; }

        public decimal SemFaleMais { get; set; }

        public DateTime DataCotacao { get; set; }

        public int PlanoId { get; set; }

        public string OrigemDDD { get; set; }

        public string DestinoDDD { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Plano Plano { get; set; }

    }
}
