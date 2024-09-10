using AutoMapper;
using IntraVisionTest.Application.Coins;
using IntraVisionTest.Controllers;
using IntraVisionTest.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IntraVisionTest.MVC.Controllers
{
    public class PayController : MvcBaseController
    {

        private readonly IMapper _mapper;
        private readonly ICoinAppService _coinAppService;

        public PayController(ICoinAppService coinAppService, IMapper mapper)
        {
            _mapper = mapper;
            _coinAppService = coinAppService;
        }

        [HttpGet]
        public IActionResult Index(int price)
        {
            var coins = _coinAppService.GetAllAsync().Result.ToList();

            if (price > 0)
            {
                return View(coins.Select(c => new CoinViewModel
                {
                    Id = c.Id,
                    Value = c.Value,
                    Count = c.Count,
                    PhotoLink = c.PhotoLink,
                    Price = price,
                }));
            }
            return View("Sorry");
        }

        [HttpGet]
        public IActionResult Finish(int deposit, int price)
        {
            var coins = _coinAppService.GetAllAsync().Result.ToList();
            Dictionary<int, int> change = GetChangeSimple(coins.Select(x => x.Value).ToArray(), (deposit - price));

            return View(coins.Select(c => new CoinViewModel
            {
                PhotoLink = c.PhotoLink,
                Count = change.First(x => x.Key == c.Value).Value,
                Change = deposit - price,
            }));
        }
        private Dictionary<int, int> GetChangeSimple(int[] values, int margin)
        {
            var coins = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 5, 0 },
                { 10,0 }
            };

            foreach (int value in values.Distinct().OrderByDescending(x => x))
            {
                coins[value] = (margin / value);
                margin %= value;
                if (margin == 0)
                    return coins;
            }
            return coins;
        }
    }
}
