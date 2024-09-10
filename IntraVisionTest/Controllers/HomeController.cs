using AutoMapper;
using IntraVisionTest.Application.Brands;
using IntraVisionTest.Application.Products;
using IntraVisionTest.Application.Products.Dto;
using IntraVisionTest.Application.ShopCard;
using IntraVisionTest.Application.ShopCard.Dto;
using IntraVisionTest.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IntraVisionTest.Controllers
{
    public class HomeController : MvcBaseController
    {
        private readonly IShopCardAppService _shopCardAppService;
        private readonly IBrandAppService _brandAppService;
        private readonly IProductAppService _productAppService;
        private readonly IMapper _mapper;

        public HomeController(IProductAppService productAppService, IBrandAppService brandAppService, IShopCardAppService shopCardAppService, IMapper mapper)
        {
            _shopCardAppService = shopCardAppService;
            _brandAppService = brandAppService;
            _productAppService = productAppService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(string? brandName = null)
        {
            IEnumerable<ProductDto> products;
            string model = _shopCardAppService.ShopCardSession();
            var brandNames = _brandAppService.GetNames().Result;

            var models = JsonSerializer.Deserialize<ShopCardDto>(_shopCardAppService.ShopCardSession());
            if (models?.ShopCard != null)
            {
                return View("Sorry");
            }

            if (brandName != null)
            {
                products = _productAppService.GetAllAsync().Result.ToList().Where(x => x.Brand!.Name == brandName);
            }
            else
            {
                products = _productAppService.GetAllAsync().Result;
            }

            //return View(_mapper.Map<ProductViewModel>(products));

            return View(products.Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.Name!,
                PhotoLink = c.PhotoLink!,
                Price = c.Price,
                Count = c.Count,
                BrandName = c.Brand!.Name,
                BrandNames = brandNames
            }));
        }

    }
}
