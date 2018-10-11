using System.Collections.Generic;

namespace RM.Basket.Library
{
    public class ProductLineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountedLineCost { get; set; }
        public decimal LineCost => Product.Price * Quantity;
    }
}
