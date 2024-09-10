using System.ComponentModel.DataAnnotations.Schema;

namespace IntraVisionTest.Domain.Entities
{
    public class Product : Entity
    {
        public required string Name { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }

        public required string PhotoLink { get; set; }
    }
}
