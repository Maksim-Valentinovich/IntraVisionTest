using AutoMapper;
using IntraVisionTest.Application.Coins.Dto;
using IntraVisionTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntraVisionTest.Application.Coins
{
    public class CoinAppService : IntraVisionAppService, ICoinAppService
    {
        public CoinAppService(IntraVisionContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<CoinDto>> GetAllAsync()
        {
            var coins = await Context.Coins.ToListAsync();
            return Mapper.Map<IEnumerable<CoinDto>>(coins);
        }
    }
}
