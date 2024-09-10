using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.Json;

namespace IntraVisionTest.Domain.Entities
{
    public class ShopCard : Entity
    {
        private static IServiceProvider? Services { get; set; }
        public static ISession? Session { get; set; }

        public List<Product>? ListShopItems { get; set; }

        public static ShopCard GetCard(IServiceProvider services)
        {
            Services = services;

            Session = Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            if (Session.GetString("ShopCard") == null)
            {
                ShopCard cardNew = new();

                string json = JsonSerializer.Serialize(cardNew);

                Session.SetString("ShopCard", json);
            }
            ShopCard? card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));

            return new ShopCard() { ListShopItems = card?.ListShopItems };
        }

        public void AddToCard(Product product)
        {
            ShopCard card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"))!;

            if (card.ListShopItems == null)
            {
                card.ListShopItems = new List<Product>() { product };
            }
            else
            {
                card.ListShopItems.Add(product);
            }

            ShopCard cardNew = new() { ListShopItems = card.ListShopItems };

            string json = JsonSerializer.Serialize(cardNew);

            Session.SetString("ShopCard", json);
        }

        public void DeleteProduct(int index)
        {
            ShopCard card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"))!;

            card.ListShopItems?.RemoveAt(index);

            ShopCard cardNew = new() { ListShopItems = card.ListShopItems };

            string json = JsonSerializer.Serialize(cardNew);

            Session.SetString("ShopCard", json);
        }

        public List<Product> GetShopItems()
        {
            var card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"))!;

            card.ListShopItems ??= new List<Product>() { };

            return card.ListShopItems;
        }
    }
}
