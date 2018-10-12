using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var products = _supermarketRepository.GetAllProducts().ToList();
            var homeViewModel = new HomeViewModel { Title = "Welcome to Richie's Discount Supermarket", Products = products, BasketId = 1 };
            return View(homeViewModel);
        }
    }
}
