using System.Collections.Generic;
using System.Linq;

namespace RM.Basket.Library
{
    public class DiscountGetNthDiscounted : IDiscount
    {
        private readonly List<int> _productIds;
        private readonly int _discountedItem;
        private readonly decimal _discountPercent;
        public DiscountGetNthDiscounted(List<int> productIds, int discountedItem, decimal discountPercent)
        {
            _productIds = productIds;
            _discountedItem = discountedItem;
            _discountPercent = discountPercent;
        }

        public List<IProductLineItem> ApplyDiscount(List<IProductLineItem> products)
        {
            foreach(int id in _productIds)
            {
                var line = products.SingleOrDefault(p => p.Product.Id == id);
                var numDiscountedItems = line.Quantity / _discountedItem;
                var numFullPricedItems = line.Quantity - numDiscountedItems;
                var fullPricedCost = numFullPricedItems * line.Product.Price;
                var discountedCost = numDiscountedItems * (line.Product.Price - line.Product.Price * _discountPercent/100);

                line.DiscountedLineCost = fullPricedCost + discountedCost;
                line.DiscountApplied = true;
            }

            return products;
        }
    }
}
