using IntraVisionTest.Application.Brands.Dto;

namespace IntraVisionTest.Application.Brands
{
    public interface IBrandAppService : IApplicationService
    {
        public Task<IEnumerable<BrandDto>> GetAllAsync();

        public Task<List<string>> GetNames();
    }
}
