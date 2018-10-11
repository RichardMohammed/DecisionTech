namespace RM.Basket.Library.Tests
{
    public class TestProducts
    {
        public static ProductLineItem BreadItem()
        {
            var breadItem = new ProductLineItem
            {
                Product = new Product { Id = 1, Name = "Bread", Price = 1.00m },
                Quantity = 1
            };

            return breadItem;
        }

        public static ProductLineItem MilkItem()
        {
            var milkItem = new ProductLineItem
            {
                Product = new Product { Id = 2, Name = "Milk", Price = 1.15m },
                Quantity = 1
            };

            return milkItem;
        }

        public static ProductLineItem ButterItem()
        {
            var butterItem = new ProductLineItem
            {
                Product = new Product { Id = 3, Name = "Butter", Price = 0.80m },
                Quantity = 1
            };

            return butterItem;
        }
    }
}
