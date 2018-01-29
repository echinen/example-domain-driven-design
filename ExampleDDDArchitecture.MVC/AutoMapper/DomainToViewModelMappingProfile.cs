using AutoMapper;
using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.MVC.ViewModels;

namespace ExampleDDDArchitecture.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CotacaoViewModel, Cotacao>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<PlanoViewModel, Plano>();
        }
    }
}