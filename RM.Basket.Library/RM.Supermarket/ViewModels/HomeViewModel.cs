using RM.Basket.Library;
using System.Collections.Generic;

namespace RM.Supermarket.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public int BasketId { get; set; }
        public List<Product> Products { get; set; }
    }
}
