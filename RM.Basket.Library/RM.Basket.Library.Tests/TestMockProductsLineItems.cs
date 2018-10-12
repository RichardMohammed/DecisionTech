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
            var milkItem = new ProductLineItem
            {
                BasketId = 1,
                Product = new Product { Id = 2, DiscountCode = 2, Name = "Milk", Price = 1.15m },
                Quantity = 1
            };

            return milkItem;
        }

        public static IProductLineItem ButterItem()
        {
            var butterItem = new ProductLineItem
            {
                BasketId = 1,
                Product = new Product { Id = 3, DiscountCode = 3, Name = "Butter", Price = 0.80m },
                Quantity = 1
            };

            return butterItem;
        }
    }
}
