using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace RM.Basket.Library.Tests
{
    // TO DO:
    // Calculate line item regular prices

    public class ProductTests
    {
        private readonly ITestOutputHelper output;

        public ProductTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(1, "Bread", 1.00, 1, 1.00)]
        [InlineData(2, "Milk", 1.15, 1, 1.15)]
        [InlineData(3, "Butter", 0.80, 1, 0.80)]
        public void CalculateLineItemPrice_Return_Total_Success(int id, string name, decimal price, int qty, decimal expected)
        {
            var productItem = new ProductLineItem {Product = new Product { Id = id, Name = name, Price = price }, Quantity=qty };

            var productTotal = productItem.LineCost;
            Assert.True(expected == productTotal);

            output.WriteLine($"{productItem.Product.Name} : {productItem.Product.Price} : {productItem.Quantity} : {productItem.LineCost}");
        }
       
    }
}
