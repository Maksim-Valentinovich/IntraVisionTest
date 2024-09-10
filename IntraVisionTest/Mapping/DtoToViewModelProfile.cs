using AutoMapper;
using IntraVisionTest.Application.Coins.Dto;
using IntraVisionTest.Application.Products.Dto;
using IntraVisionTest.Application.ShopCard.Dto;
using IntraVisionTest.MVC.ViewModels;

namespace IntraVisionTest.MVC.Mapping
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<ShopCardDto, ShopCardViewModel>();

            CreateMap<ProductDto, ProductViewModel>()
               .ForMember(dest => dest.BrandName, opt => opt.MapFrom((src, dest) => src.Brand.Name));

            CreateMap<CoinDto, CoinViewModel>()
               .ForMember(dest => dest.Change, opt => opt.MapFrom((src, dest) => src.Count));
        }
    }
}
