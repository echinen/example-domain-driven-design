using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.Domain.Interfaces.Repositories;
using ExampleDDDArchitecture.Domain.Interfaces.Services;
using ExampleDDDArchitecture.Infra.CrossCutting;


namespace ExampleDDDArchitecture.Domain.Services
{
    public class CotacaoService : ServiceBase<Cotacao>, ICotacaoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public CotacaoService(ICotacaoRepository cotacaoRepository)
            : base(cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public Cotacao ToDoQuotation(string origemDDD, string destinoDDD, int plano, int tempo)
        {
            Cotacao novaCotacao;
            var origem = origemDDD;
            var destino = destinoDDD;
            var tarifa = CheckIfTariffExist(origem, destino);
            int planoTempo;
            int tempoLigacao = tempo;
            decimal comFaleMais = 0;
            decimal semFaleMais;

            var tipoPlano = FindPlan(plano).TipoPlano;
            planoTempo = int.Parse(Helper.ExtrairNumeros(tipoPlano));

            //Regra 1 - ComFaleMais
            if (tempoLigacao <= planoTempo)
            {
                comFaleMais = 0;
            }
            else if (tempoLigacao > planoTempo)
            {
                //tempo excedente - é a diferença entre o tempo de ligação e o tipo de plano escolhido.
                var tempoExcedente = tempoLigacao - planoTempo;

                //10% de acréscimo na tarifa, se tiver tempo excedente além do tipo de plano escolhido.
                decimal taxaExtraTarifa = 1.1M;
                var novaTarifaComAcrescimo = tarifa * taxaExtraTarifa;

                comFaleMais = tempoExcedente * novaTarifaComAcrescimo;
            }

            //Regra 2 - SemFaleMais
            semFaleMais = tempoLigacao * tarifa;

            novaCotacao = new Cotacao()
            {
                ComFaleMais = comFaleMais,
                SemFaleMais = semFaleMais
            };

            return novaCotacao;
        }

        public decimal CheckIfTariffExist(string origemDDD, string destinoDDD)
        {
            var tarifa = _cotacaoRepository.CheckIfTariffExist(origemDDD, destinoDDD);

            return tarifa;
        }

        public Plano FindPlan(int id)
        {
            return _cotacaoRepository.FindPlan(id);
        }
    }
}
