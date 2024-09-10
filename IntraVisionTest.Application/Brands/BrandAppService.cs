using AutoMapper;
using IntraVisionTest.Application.Brands.Dto;
using IntraVisionTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntraVisionTest.Application.Brands
{
    public class BrandAppService : IntraVisionAppService, IBrandAppService
    {
        public BrandAppService(IntraVisionContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var brands = await Context.Brands.ToListAsync();
            return Mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<List<string>> GetNames()
        {
            return await Context.Brands.Select(x => x.Name).ToListAsync();
        }
    }
}
