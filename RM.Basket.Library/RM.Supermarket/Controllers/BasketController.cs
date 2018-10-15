using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RM.Supermarket.Models;
using RM.Supermarket.ViewModels;
using RM.Basket.Library;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RM.Supermarket.Controllers
{
    public class BasketController : Controller
    {
        private readonly ISupermarketRepository _supermarketRepository;
        private readonly ShoppingBasket _basket;

        public BasketController(ISupermarketRepository supermarketRepository)
        {
            _supermarketRepository = supermarketRepository;
            _basket = ShoppingBasket.GetBasket(1); // We will need to update to get basket id from DB or Session / cookies etc
            _basket.Products = _supermarketRepository.GetAllLineItemsByBasketId(_basket.BasketId).ToList();
        }

        public IActionResult Index(int basketId)
        {
            var productLines = _supermarketRepository.GetAllLineItemsByBasketId(basketId).ToList();
            _basket.Products = productLines;

            var basketViewModel = new BasketViewModel
            {
                BasketId = _basket.BasketId,
                ProductLineItems = _basket.Products,
                Total = _basket.GetTotal()
            };

            return View(basketViewModel);
        }

        public IActionResult UpdateTotal(int basketId)
        {
            _basket.UpdateTotalWithPromotions();
            foreach(ProductLineItem item in _basket.Products)
            {
                _supermarketRepository.SaveBasketLineItem(_basket.BasketId, item);
            }

            var basketViewModel = new BasketViewModel
            {
                BasketId = _basket.BasketId,
                ProductLineItems = _basket.Products,
                Total = _basket.GetDiscountedTotal()
            };

            return View("Index", basketViewModel);
        }

        public RedirectToActionResult AddToBasket(int productId)
        {
            var product = _supermarketRepository.GetProductById(productId);
            _basket.AddProduct(product, 1);

            var basketLineItem = _basket.Products.FirstOrDefault(p => p.Product.Id == product.Id);
            _supermarketRepository.SaveBasketLineItem(_basket.BasketId, basketLineItem);
            return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult Delete(int basketLineId)
        {
            _supermarketRepository.DeleteLineItem(basketLineId);
            return RedirectToAction("Index", "Basket", new { _basket.BasketId });
        }

    }
}
