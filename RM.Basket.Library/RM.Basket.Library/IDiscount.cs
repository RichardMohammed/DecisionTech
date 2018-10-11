using System.Collections.Generic;

namespace RM.Basket.Library
{
    public interface IDiscount
    {
        List<ProductLineItem> ApplyDiscount(List<ProductLineItem> products);
    }
}