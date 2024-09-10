using IntraVisionTest.Application.Common;

namespace IntraVisionTest.Application.Coins.Dto
{
    public class CoinDto : EntityDto
    {
        public int Value { get; set; }
        public int Count { get; set; }
        public string? PhotoLink { get; set; }
    }
}
