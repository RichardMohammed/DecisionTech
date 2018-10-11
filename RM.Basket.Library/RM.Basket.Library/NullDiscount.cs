using System.Collections.Generic;

namespace RM.Basket.Library
{
    public class NullDiscount : IDiscount
    {
        public List<ProductLineItem> ApplyDiscount(List<ProductLineItem> products)
        {
            return products;
        }
    }
}