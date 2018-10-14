using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Basket.Library
{
    public class Discount
    {
        public int Id { get; set; }
        public int SourceProductId { get; set; }
        public int TargetProductId { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
