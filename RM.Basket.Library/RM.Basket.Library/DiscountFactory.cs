using System.Collections.Generic;

namespace RM.Basket.Library
{
    public class DiscountFactory
    {
        public static IDiscount GetDiscount(int productId, Discount discount)
        {
            if (discount == null)
                return new NullDiscount();

            switch (discount.Id)
            {
                case 1: return new DiscountBuyNofXGetOneYhalfPrice(new List<int> { productId }, 2, discount.TargetProductId, discount.DiscountAmount);
                case 2: return new DiscountGetNthDiscounted(new List<int> { productId }, 4, 100); // 100% off 4th item
                default: return new NullDiscount();
            }
        }
    }
}