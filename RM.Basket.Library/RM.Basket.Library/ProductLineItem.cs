using System.Collections.Generic;

namespace RM.Basket.Library
{
    public class ProductLineItem: IProductLineItem
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountedLineCost { get; set; }
        public bool DiscountApplied { get;  set; }
    }
}
