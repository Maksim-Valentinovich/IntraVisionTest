namespace IntraVisionTest.Domain.Entities
{
    public class Coin : Entity
    {
        public int Value { get; set; }

        public int Count { get; set; }

        public required string PhotoLink { get; set; }
    }
}
