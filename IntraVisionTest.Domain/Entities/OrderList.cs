using System.ComponentModel.DataAnnotations.Schema;

namespace IntraVisionTest.Domain.Entities
{
    public class OrderList
    {
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }


        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }


        public int Count { get; set; }
    }
}
