using AutoMapper;
using IntraVisionTest.Application.ShopCard;
using IntraVisionTest.Controllers;
using IntraVisionTest.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IntraVisionTest.MVC.Controllers
{
    public class ShopCardController : MvcBaseController
    {
        private readonly IMapper _mapper;
        private readonly IShopCardAppService _shopCardAppService;

        public ShopCardController(IShopCardAppService shopCardAppService, IMapper mapper)
        {
            _shopCardAppService = shopCardAppService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _shopCardAppService.GetShopItems();

            return View(_mapper.Map<ShopCardViewModel>(model));
        }

        [Route("ShopCard/AddToCard")]
        [HttpGet]
        public async Task<RedirectToActionResult> AddToCard(int productId)
        {
            await _shopCardAppService.AddProduct(productId);
            return RedirectToAction("Index");
        }

        [Route("ShopCard/DeleteProductOnCard")]
        [HttpGet("indx")]
        public IActionResult DeleteProductOnCard(int indx)
        {
            _shopCardAppService.DeleteProduct(indx);
            return Ok();
        }

        [Route("ShopCard/Product")]
        [HttpGet]
        public IActionResult Product()
        {
            var model = _shopCardAppService.GetShopItems();
            return PartialView("_Product", _mapper.Map<ShopCardViewModel>(model));
        }

        [Route("ShopCard/ClearShopCard")]
        [HttpGet]
        public void ClearShopCard()
        {
            _shopCardAppService.ClearShopCard();
        }

    }
}
