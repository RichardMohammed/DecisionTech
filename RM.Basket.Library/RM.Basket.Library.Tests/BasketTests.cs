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

    // REFERENCE for parameterised tests 
    // https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/

    public class BasketTests
    {
        private readonly ITestOutputHelper _output;
        public BasketTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(Products))]
        public void AddLineItems_ToBasket_UpdatesTotalAndLineCount_Success(IEnumerable<Product> products, int expectedCount, decimal expectedTotal)
        {
            var basket = new ShoppingBasket();

            foreach (Product p in products) {
                basket.AddProduct(p, 1);
            }

            _output.WriteLine($"Count: {basket.Products.Count}, Total: {basket.GetTotal()}");

            Assert.True(basket.Products.Count == expectedCount);
            Assert.True(basket.GetTotal() == expectedTotal);
        }

        [Fact]
        public void AddMultipleSameItem_UpdatesLineCount_Success()
        {
            var basket = new ShoppingBasket();
            var bread1 = TestMockProductsLineItems.BreadItem();
            var bread2 = TestMockProductsLineItems.BreadItem();

            basket.AddProduct(bread1.Product, 1);
            basket.AddProduct(bread2.Product, 1);

            Assert.True(basket.Products[0].Quantity == 2 && basket.Products[0].Product.Id == 1);
            Assert.True(basket.GetTotal() == 2.00m);
            Assert.True(basket.Products.Count == 1);
        }

        [Fact]
        public void DeleteLineItem_Success()
        {
            var basket = new ShoppingBasket();
            var bread1 = TestMockProductsLineItems.BreadItem();
            var bread2 = TestMockProductsLineItems.BreadItem();

            basket.AddProduct(bread1.Product, 1);
            basket.AddProduct(bread2.Product, 1);

            _output.WriteLine($"Total before delete: {basket.Products.Count}");
            basket.DeleteProductLine(1);

            _output.WriteLine($"Total after delete: {basket.Products.Count}");
            Assert.True(basket.Products.Count == 0);
        }

        [Theory]
        [MemberData(nameof(DiscountedProductsGet4thFree))]
        public void UpdateTotals_ApplyPromotions_Get4thFree_Success(IEnumerable<IProductLineItem> products, decimal expectedDiscountedPrice)
        {
            var basket = new ShoppingBasket();

            foreach (IProductLineItem p in products)
            {
                basket.AddProduct(p.Product, 1);
            }

            basket.UpdateTotalWithPromotions();

            _output.WriteLine($"basket total: {basket.GetDiscountedTotal()} expected: {expectedDiscountedPrice}");
            Assert.True(basket.GetDiscountedTotal() == expectedDiscountedPrice);
        }

        [Theory]
        [MemberData(nameof(DiscountedProductsGetHalfPrice))]
        public void UpdateTotals_ApplyPromotions_GetHalfPriceBread_When_2Butter(IEnumerable<IProductLineItem> products, decimal expectedDiscountedPrice)
        {
            var basket = new ShoppingBasket();

            foreach (IProductLineItem p in products)
            {
                basket.AddProduct(p.Product, 1);
            }

            basket.UpdateTotalWithPromotions();
            _output.WriteLine($"basket total: {basket.GetDiscountedTotal()} expected: {expectedDiscountedPrice}");
            Assert.True(basket.GetDiscountedTotal() == expectedDiscountedPrice);
        }

        public static IEnumerable<object[]> Products()
        {
            var products = new List<Product> { TestMockProductsLineItems.BreadItem().Product };
            var products2 = new List<Product> { TestMockProductsLineItems.BreadItem().Product, TestMockProductsLineItems.BreadItem().Product };
            var products3 = new List<Product> { TestMockProductsLineItems.BreadItem().Product, TestMockProductsLineItems.ButterItem().Product, TestMockProductsLineItems.MilkItem().Product };
            var products4 = new List<Product> { TestMockProductsLineItems.BreadItem().Product, TestMockProductsLineItems.ButterItem().Product, TestMockProductsLineItems.MilkItem().Product, TestMockProductsLineItems.MilkItem().Product };

            yield return new object[] { products, 1, 1.00m };
            yield return new object[] { products2, 1, 2.00m }; // Line items should still be 1 but total 2
            yield return new object[] { products3, 3, 2.95m };
            yield return new object[] { products4, 3, 4.10m };
        }

        public static IEnumerable<object[]> DiscountedProductsGet4thFree()
        {
            var products = new List<IProductLineItem> { TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem() };
            var products2 = new List<IProductLineItem> { TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem() };
            var products3 = new List<IProductLineItem> { TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(),
                                                        TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem(), TestMockProductsLineItems.MilkItem() };

            yield return new object[] { products, 3.45m };
            yield return new object[] { products2, 4.60m };
            yield return new object[] { products3, 6.90m };
        }

        public static IEnumerable<object[]> DiscountedProductsGetHalfPrice()
        {
            var products = new List<IProductLineItem> { TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.BreadItem(), TestMockProductsLineItems.BreadItem() };
            var products2 = new List<IProductLineItem> { TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(),
                                                        TestMockProductsLineItems.BreadItem(), TestMockProductsLineItems.BreadItem()
                                                      };
            var products3 = new List<IProductLineItem> { TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(), TestMockProductsLineItems.ButterItem(),
                                                        TestMockProductsLineItems.BreadItem(), TestMockProductsLineItems.BreadItem(), TestMockProductsLineItems.BreadItem()
                                                      };

            yield return new object[] { products, 3.10m };
            yield return new object[] { products2, 4.20m };
            yield return new object[] { products3, 5.20m };
        }

    }
}
