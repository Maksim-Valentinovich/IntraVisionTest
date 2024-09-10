using IntraVisionTest.Application.Common;
using IntraVisionTest.Domain.Entities;

namespace IntraVisionTest.Application.Products.Dto
{
    public class ProductDto : EntityDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string? PhotoLink { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
