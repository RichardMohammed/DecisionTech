using System.Collections.Generic;

namespace RM.Basket.Library
{
    public interface IDiscount
    {
        List<IProductLineItem> ApplyDiscount(List<IProductLineItem> products);
    }
}