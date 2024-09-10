using IntraVisionTest.Application.ShopCard.Dto;

namespace IntraVisionTest.Application.ShopCard
{
    public interface IShopCardAppService : IApplicationService
    {
        Task AddProduct(int productId);

        void DeleteProduct(int index);

        public ShopCardDto GetShopItems();

        public string ShopCardSession();

        public void ClearShopCard();
    }
}
