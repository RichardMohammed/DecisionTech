using System.Collections.Generic;
using System.Linq;

namespace RM.Basket.Library
{
    public class DiscountBuyNofXGetOneYhalfPrice : IDiscount
    {
        private readonly List<int> _productIds;
        private readonly int _numRequired;
        private readonly int _discountedProductId;
        private readonly decimal _discount;

        public DiscountBuyNofXGetOneYhalfPrice(List<int> productIds, int numRequired, int discountedProductId, decimal discount)
        {
            _productIds = productIds;
            _numRequired = numRequired;
            _discountedProductId = discountedProductId;
            _discount = discount;
        }

        public List<ProductLineItem> ApplyDiscount(List<ProductLineItem> products)
        {
            foreach (int id in _productIds)
            {
                var line = products.SingleOrDefault(p => p.Product.Id == id);
                var numDiscountedYItems = line.Quantity / _numRequired;
                var yLineItem = products.SingleOrDefault(p => p.Product.Id == _discountedProductId);

                var numFullPricedYItems = yLineItem.Quantity - numDiscountedYItems;
                numFullPricedYItems = numFullPricedYItems < 0 ? 0 : numFullPricedYItems;
                numDiscountedYItems = numDiscountedYItems < yLineItem.Quantity ? numDiscountedYItems : yLineItem.Quantity;
                var fullPricedCost = numFullPricedYItems * yLineItem.Product.Price;
                var discountedCost = numDiscountedYItems * (yLineItem.Product.Price * _discount/100);

                yLineItem.DiscountedLineCost = fullPricedCost + discountedCost;
                line.DiscountedLineCost = line.LineCost;
            }

            return products;
        }
    }
}
