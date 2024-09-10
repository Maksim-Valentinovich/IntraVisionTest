using IntraVisionTest.Application.Products.Dto;

namespace IntraVisionTest.Application.Products
{
    public interface IProductAppService : IApplicationService
    {
        public Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}
