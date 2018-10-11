using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace RM.Basket.Library.Tests
{
    //TO DO
    // Add item to basket
    // Increment item quantity in basket
    // Remove item from basket
    // Calculate basket Total

    // Adjust basket Total based on Item Promotions

    // Promotional items
    // buy 2 butter get bread 50% off
    // every 4th bread free

    // REFERENCE
    // https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/

    public class BasketTests
    {
        private readonly ITestOutputHelper output;
        public BasketTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [MemberData(nameof(Products))]
        public void AddLineItems_ToBasket_UpdatesTotalAndLineCount_Success(IEnumerable<ProductLineItem> products, int expectedCount, decimal expectedTotal)
        {
            var basket = new Basket();

            foreach (ProductLineItem p in products) {
                basket.AddProductLine(p);
            }

            output.WriteLine($"Count: {basket.Products.Count}, Total: {basket.Total}");

            Assert.True(basket.Products.Count == expectedCount);
            Assert.True(basket.Total == expectedTotal);
        }

        [Fact]
        public void AddMultipleSameItem_UpdatesLineCount_Success()
        {
            var basket = new Basket();
            var bread1 = TestProducts.BreadItem();
            var bread2 = TestProducts.BreadItem();

            basket.AddProductLine(bread1);
            basket.AddProductLine(bread2);

            Assert.True(basket.Products[0].Quantity == 2 && basket.Products[0].Product.Id == 1);
            Assert.True(basket.Total == 2.00m);
            Assert.True(basket.Products.Count == 1);
        }

        [Fact]
        public void DeleteLineItem_Success()
        {
            var basket = new Basket();
            var bread1 = TestProducts.BreadItem();
            var bread2 = TestProducts.BreadItem();

            basket.AddProductLine(bread1);
            basket.AddProductLine(bread2);

            output.WriteLine($"Total before delete: {basket.Products.Count}");
            basket.DeleteProductLine(1);

            output.WriteLine($"Total after delete: {basket.Products.Count}");
            Assert.True(basket.Products.Count == 0);
        }

        [Theory]
        [MemberData(nameof(DiscountedProductsGet4thFree))]
        public void UpdateTotals_ApplyPromotions_Get4thFree_Success(IEnumerable<ProductLineItem> products, decimal expectedDiscountedPrice)
        {
            var basket = new Basket();

            foreach (ProductLineItem p in products)
            {
                basket.AddProductLine(p);
            }

            basket.UpdateTotalWithPromotions();

            output.WriteLine($"basket total: {basket.DiscountedTotal} expected: {expectedDiscountedPrice}");
            Assert.True(basket.DiscountedTotal == expectedDiscountedPrice);
        }

        [Theory]
        [MemberData(nameof(DiscountedProductsGetHalfPrice))]
        public void UpdateTotals_ApplyPromotions_GetHalfPriceBread_When_2Butter(IEnumerable<ProductLineItem> products, decimal expectedDiscountedPrice)
        {
            var basket = new Basket();

            foreach (ProductLineItem p in products)
            {
                basket.AddProductLine(p);
            }

            basket.UpdateTotalWithPromotions();
            output.WriteLine($"basket total: {basket.DiscountedTotal} expected: {expectedDiscountedPrice}");
            Assert.True(basket.DiscountedTotal == expectedDiscountedPrice);
        }

        public static IEnumerable<object[]> Products()
        {
            var products = new List<ProductLineItem> { TestProducts.BreadItem() };
            var products2 = new List<ProductLineItem> { TestProducts.BreadItem(), TestProducts.BreadItem() };
            var products3 = new List<ProductLineItem> { TestProducts.BreadItem(), TestProducts.ButterItem(), TestProducts.MilkItem() };
            var products4 = new List<ProductLineItem> { TestProducts.BreadItem(), TestProducts.ButterItem(), TestProducts.MilkItem(), TestProducts.MilkItem() };

            yield return new object[] { products, 1, 1.00m };
            yield return new object[] { products2, 1, 2.00m }; // Line items should still be 1 but total 2
            yield return new object[] { products3, 3, 2.95m };
            yield return new object[] { products4, 3, 4.10m };
        }

        public static IEnumerable<object[]> DiscountedProductsGet4thFree()
        {
            var products = new List<ProductLineItem> { TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem() };
            var products2 = new List<ProductLineItem> { TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem() };
            var products3 = new List<ProductLineItem> { TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem(),
                                                        TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem(), TestProducts.MilkItem() };

            yield return new object[] { products, 3.45m };
            yield return new object[] { products2, 4.60m };
            yield return new object[] { products3, 6.90m };
        }

        public static IEnumerable<object[]> DiscountedProductsGetHalfPrice()
        {
            var products = new List<ProductLineItem> { TestProducts.ButterItem(), TestProducts.ButterItem(), TestProducts.BreadItem(), TestProducts.BreadItem() };
            var products2 = new List<ProductLineItem> { TestProducts.ButterItem(), TestProducts.ButterItem(), TestProducts.ButterItem(), TestProducts.ButterItem(),
                                                        TestProducts.BreadItem(), TestProducts.BreadItem()
                                                      };
            var products3 = new List<ProductLineItem> { TestProducts.ButterItem(), TestProducts.ButterItem(), TestProducts.ButterItem(), TestProducts.ButterItem(),
                                                        TestProducts.BreadItem(), TestProducts.BreadItem(), TestProducts.BreadItem()
                                                      };

            yield return new object[] { products, 3.10m };
            yield return new object[] { products2, 4.20m };
            yield return new object[] { products3, 5.20m };
        }

    }
}
