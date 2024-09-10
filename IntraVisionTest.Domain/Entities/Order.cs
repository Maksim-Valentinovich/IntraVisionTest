namespace IntraVisionTest.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
