using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExampleDDDArchitecture.MVC.ViewModels
{
    public class PlanoViewModel
    {
        [Key]
        [Display(Name = "Código do Plano")]
        public int PlanoId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome do Plano!")]
        [Display(Name="Nome do Plano")]
        [MaxLength(15)]
        public string TipoPlano { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}