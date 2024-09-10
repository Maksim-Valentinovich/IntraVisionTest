using AutoMapper;
using IntraVisionTest.Application.ShopCard.Dto;
using IntraVisionTest.Domain;
using IntraVisionTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace IntraVisionTest.Application.ShopCard
{
    public class ShopCardAppService : IntraVisionAppService, IShopCardAppService
    {
        public ShopCardAppService(IntraVisionContext context, Domain.Entities.ShopCard shopCard, IMapper mapper) : base(context, shopCard, mapper)
        {
        }

        public async Task AddProduct(int productId)
        {
            Product product = await Context.Products.FirstAsync(c => c.Id == productId);

            ShopCard?.AddToCard(product);
        }

        public void DeleteProduct(int index)
        {
            ShopCard?.DeleteProduct(index);
        }

        public ShopCardDto GetShopItems()
        {
            var items = ShopCard!.GetShopItems();

            ShopCard.ListShopItems = items;

            ShopCardDto shopCardDto = new()
            {
                ShopCard = ShopCard,
            };

            return shopCardDto;
        }

        public string ShopCardSession()
        {
            var model = Domain.Entities.ShopCard.Session.GetString("ShopCard");
            return model;
        }

        public void ClearShopCard()
        {
            Domain.Entities.ShopCard.Session!.Clear();
        }
    }
}
