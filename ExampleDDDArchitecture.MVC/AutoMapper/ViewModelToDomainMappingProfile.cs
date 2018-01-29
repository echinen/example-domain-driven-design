using AutoMapper;
using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.MVC.ViewModels;

namespace ExampleDDDArchitecture.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cotacao, CotacaoViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Plano, PlanoViewModel>();
        }
    }
}