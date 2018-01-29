using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleDDDArchitecture.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        //[Key]
        //[Display(Name = "Código do Produto")]
        //public int ProdutoId { get; set; }
        
        [Key]
        [Column(Order=1)]
        [Display(Name = "Origem DDD")]
        [Required(ErrorMessage = "Preencha o campo Origem DDD!")]
        [MaxLength(3, ErrorMessage="Obrigatório ter 3 caracteres! Ex: 011"), MinLength(3,ErrorMessage="Obrigatório ter 3 caracteres! Ex: 011")]
        public string OrigemDDD { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Destino DDD")]
        [Required(ErrorMessage = "Preencha o campo Destino DDD!")]
        [MaxLength(3, ErrorMessage = "Obrigatório ter 3 caracteres! Ex: 011"), MinLength(3, ErrorMessage = "Obrigatório ter 3 caracteres! Ex: 011")]
        public string DestinoDDD { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tarifa!")]
        [DataType(DataType.Currency)]
        public decimal Tarifa { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}