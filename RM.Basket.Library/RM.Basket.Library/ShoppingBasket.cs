using System;
using System.Collections.Generic;
using System.Linq;

namespace RM.Basket.Library
{
    public class ShoppingBasket
    {
        public int BasketId { get; set; }
        public List<IProductLineItem> Products { get; set; }

        public static ShoppingBasket GetBasket(int basketId)
        {
            return new ShoppingBasket { BasketId = basketId, Products = new List<IProductLineItem>()};
        }

        public ShoppingBasket()
        {
            Products = new List<IProductLineItem>();
        }

        public decimal GetTotal()
        {
            if (Products.Count == 0)
                return 0.00m;

            return Products.Sum(p => (p.Quantity * p.Product.Price));
        }

        public decimal GetDiscountedTotal()
        {
            if (Products.Count == 0)
                return 0.00m;

            return Products.Sum(p => p.DiscountedLineCost);
        }

        public void AddProduct(Product item, int quantity)
        {
            if (Products.Count > 0 && Products.Any(p => p.Product.Id  == item.Id)){
                Products.Where(p => p.Product.Id == item.Id).Single().Quantity += quantity;
            }
            else
            {
                var productLineItem = new ProductLineItem { Product = item, Quantity = quantity, BasketId = BasketId };
                Products.Add(productLineItem);
            }
        }

        public void DeleteProductLine(int productId)
        {
            if(Products.Count > 0)
            {
                Products.RemoveAll(p => p.Product.Id == productId);
            }
        }

        public void UpdateTotalWithPromotions()
        {
            foreach(IProductLineItem p in Products)
            {
                var discount = DiscountFactory.GetDiscount(p.Product.Id, p.Product.DiscountCode);
                Products = discount.ApplyDiscount(Products);
            }
        }
    }
}
