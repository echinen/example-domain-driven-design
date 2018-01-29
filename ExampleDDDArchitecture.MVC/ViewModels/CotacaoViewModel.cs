using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleDDDArchitecture.MVC.ViewModels
{
    public class CotacaoViewModel
    {
        [Key]
        [Display(Name = "Código da Cotação")]
        public int CotacaoId { get; set; }

        [Required(ErrorMessage="Preencha o campo Tempo de Ligacao!")]
        [Display(Name = "Tempo de Ligação")]
        public int TempoLigacao { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Com Fale Mais")]
        public decimal ComFaleMais { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Sem Fale Mais")]
        public decimal SemFaleMais { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCotacao { get; set; }

        //public int ProdutoId { get; set; }

        [Display(Name = "Origem DDD")]
        [Required(ErrorMessage = "Preencha o campo Origem DDD!")]
        [MaxLength(3, ErrorMessage = "Obrigatório ter 3 caracteres! Ex: 011"), MinLength(3, ErrorMessage = "Obrigatório ter 3 caracteres! Ex: 011")]
        [ForeignKey("ProdutoViewModel")]
        [Column(Order = 1)]
        public string OrigemDDD { get; set; }

        [Display(Name = "Destino DDD")]
        [Required(ErrorMessage = "Preencha o campo Destino DDD!")]
        [MaxLength(3, ErrorMessage = "Obrigatório ter 3 caracteres! Ex: 011"), MinLength(3, ErrorMessage = "Obrigatório ter 3 caracteres! Ex: 016")]
        [ForeignKey("ProdutoViewModel")]
        [Column(Order = 2)]
        public string DestinoDDD { get; set; }

        [Display(Name = "Tipo de Plano")]
        [Required(ErrorMessage = "Escolha o plano desejado!")]
        public int PlanoId { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }

        public virtual PlanoViewModel Plano { get; set; }
    }
}