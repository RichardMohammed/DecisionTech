using System.Collections.Generic;

namespace RM.Basket.Library
{
    public class DiscountFactory
    {
        public static IDiscount GetDiscount(int productId, int discountId)
        {
            switch (discountId)
            {
                case 2: return new DiscountGetNthDiscounted(new List<int> { productId }, 4, 100); // 100% off 4th item
                case 3: return new DiscountBuyNofXGetOneYhalfPrice(new List<int> { productId }, 2, 4, 50);
                default: return new NullDiscount();
            }
        }
    }
}