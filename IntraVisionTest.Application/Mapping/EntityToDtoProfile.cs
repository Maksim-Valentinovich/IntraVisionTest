using AutoMapper;
using IntraVisionTest.Application.Brands.Dto;
using IntraVisionTest.Application.Coins.Dto;
using IntraVisionTest.Application.Products.Dto;
using IntraVisionTest.Domain.Entities;

namespace IntraVisionTest.Application.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Coin, CoinDto>();
        }
    }
}
