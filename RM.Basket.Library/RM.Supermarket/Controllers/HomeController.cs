using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RM.Supermarket.Models;
using RM.Supermarket.ViewModels;

namespace RM.Supermarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISupermarketRepository _supermarketRepository;
        public HomeController(ISupermarketRepository supermarketRepository)
        {
            _supermarketRepository = supermarketRepository;
        }

        public IActionResult Index()
        {
            var basketId = 1; // Use constant basket Id for demo. Could be fetched from the DB for the particular User or created and stored in Session.
            var products = _supermarketRepository.GetAllProducts().ToList();
            var basketCount = _supermarketRepository.GetBasketItemsCount(basketId);
            var homeViewModel = new HomeViewModel {Title = "Welcome to Richie's Discount Supermarket",
                                                   Products = products, BasketId = basketId,
                                                   BasketItemsCount = basketCount};
            return View(homeViewModel);
        }
    }
}
