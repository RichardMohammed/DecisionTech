using System.Collections.Generic;
using System.Linq;

namespace RM.Basket.Library
{
    public class NullDiscount : IDiscount
    {
        public List<IProductLineItem> ApplyDiscount(List<IProductLineItem> products)
        {
            products.Where(l => l.DiscountApplied == false).ToList()
                .ForEach(p => p.DiscountedLineCost = p.Product.Price * p.Quantity);
            return products;
        }
    }
}