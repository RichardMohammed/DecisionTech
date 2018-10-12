using RM.Basket.Library;
using System.Collections.Generic;

namespace RM.Supermarket.ViewModels
{
    public class BasketViewModel
    {
        public int BasketId { get; set; }
        public decimal Total { get; set; }
        public List<IProductLineItem> ProductLineItems { get; set; }
    }
}
