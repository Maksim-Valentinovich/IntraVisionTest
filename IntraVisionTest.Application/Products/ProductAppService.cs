using AutoMapper;
using IntraVisionTest.Application.Products.Dto;
using IntraVisionTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntraVisionTest.Application.Products
{
    public class ProductAppService : IntraVisionAppService, IProductAppService
    {
        public ProductAppService(IntraVisionContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await Context.Products.Include(x => x.Brand).ToListAsync();
            return Mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
