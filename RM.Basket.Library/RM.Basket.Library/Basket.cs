using System.Collections.Generic;
using System.Linq;

namespace RM.Basket.Library
{
    public class Basket
    {
        public List<ProductLineItem> Products { get; set; }
        public decimal Total => Products.Sum(p => p.LineCost);
        public decimal DiscountedTotal => Products.Sum(p => p.DiscountedLineCost);

        public Basket()
        {
            Products = new List<ProductLineItem>();
        }

        public void AddProductLine(ProductLineItem item)
        {
            if (Products.Any(p => p.Product.Id  == item.Product.Id)){
                Products.Where(p => p.Product.Id == item.Product.Id).Single().Quantity += item.Quantity;
            }
            else
            {
                Products.Add(item);
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
            foreach(ProductLineItem p in Products)
            {
                var discount = DiscountFactory.GetDiscount(p.Product.Id);
                Products = discount.ApplyDiscount(Products);
            }
        }
    }
}
