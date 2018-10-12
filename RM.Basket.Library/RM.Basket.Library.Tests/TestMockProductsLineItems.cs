namespace RM.Basket.Library.Tests
{
    public class TestMockProductsLineItems
    {
        public static IProductLineItem BreadItem()
        {
            var breadItem = new ProductLineItem
            {
                BasketId = 1,
                Product = new Product { Id = 1, Name = "Bread", Price = 1.00m },
                Quantity = 1
            };

            return breadItem;
        }

        public static IProductLineItem MilkItem()
        {
            var discount = new Discount { Id = 2, DiscountAmount = 100m, TargetProductId = 2 };
            var milkItem = new ProductLineItem
            {
                BasketId = 1,
                Product = new Product { Id = 2, Discount = discount, Name = "Milk", Price = 1.15m },
                Quantity = 1
            };

            return milkItem;
        }

        public static IProductLineItem ButterItem()
        {
            var discount = new Discount { Id = 1, DiscountAmount = 50m, TargetProductId = 1 };

            var butterItem = new ProductLineItem
            {
                BasketId = 1,
                Product = new Product { Id = 3, Discount = discount, Name = "Butter", Price = 0.80m },
                Quantity = 1
            };

            return butterItem;
        }
    }
}
