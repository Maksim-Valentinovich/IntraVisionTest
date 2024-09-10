using IntraVisionTest.Application.Coins.Dto;

namespace IntraVisionTest.Application.Coins
{
    public interface ICoinAppService : IApplicationService
    {
        public Task<IEnumerable<CoinDto>> GetAllAsync();
    }
}
