using Xunit;
using Microsoft.Data.Sqlite;
using RM.Supermarket.Models;
using RM.Supermarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using RM.Supermarket.ViewModels;

namespace RM.Supermarket.Integration.Tests
{
    //• Option 1 -  Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
    //• Option 2 -  Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
    //• Option 3 -  Given the basket has 4 milk when I total the basket then the total should be £3.45
    //• Option 4 -  Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00
    public class BasketControllerTests
    {
        SqliteConnection _connection;
        int _basketId = 1;
        public BasketControllerTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
        }

        [Fact]
        public void BasketController_AddToBasket_Test_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);
                // Add products to Test DB
                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    var repo = new SupermarketRepository(context);
                    var controller = new BasketController(repo);

                    // Add 4 containers of milk to the basket. 1 line item
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);

                    var result = controller.Index(_basketId) as ViewResult;
                    Assert.NotNull(result);
                    var model = result.Model as BasketViewModel;
                    Assert.True(model.BasketId == 1);
                    Assert.True(model.ProductLineItems.Count == 1);

                    // Basket total before discount
                    Assert.True(model.Total == 4.60m);

                    var updatedresult = controller.UpdateTotal(_basketId) as ViewResult;
                    var updatedViewModel = updatedresult.Model as BasketViewModel;
                    Assert.True(updatedViewModel.Total == 3.45m);
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void Option1_TestDiscount_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);
                // Add products and discounts to Test DB
                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    var repo = new SupermarketRepository(context);
                    var controller = new BasketController(repo);
                    var expectedTotal = 2.95m;
                    var expectedLineCount = 3;

                    // Add 1 bread, 1 milk and 1 butter
                    controller.AddToBasket(1);
                    controller.AddToBasket(2);
                    controller.AddToBasket(3);

                    var model = (controller.Index(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(model.ProductLineItems.Count == expectedLineCount);
                    Assert.True(model.Total == expectedTotal); // Basket total before discount

                    var updatedViewModel = (controller.UpdateTotal(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(updatedViewModel.Total == expectedTotal); // Basket Total after update
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void Option2_TestDiscount_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);
                // Add products and discounts to Test DB
                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    var repo = new SupermarketRepository(context);
                    var controller = new BasketController(repo);
                    var expectedOriginalTotal = 3.60m;
                    var expectedDiscountedTotal = 3.10m;
                    var expectedLineCount = 2;

                    // Add 2 bread, 2 butter
                    controller.AddToBasket(1);
                    controller.AddToBasket(1);
                    controller.AddToBasket(3);
                    controller.AddToBasket(3);

                    var model = (controller.Index(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(model.ProductLineItems.Count == expectedLineCount);
                    Assert.True(model.Total == expectedOriginalTotal); // Basket total before discount

                    var updatedViewModel = (controller.UpdateTotal(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(updatedViewModel.Total == expectedDiscountedTotal); // Basket Total after update
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void Option3_TestDiscount_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);
                // Add products and discounts to Test DB
                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    var repo = new SupermarketRepository(context);
                    var controller = new BasketController(repo);
                    var expectedOriginalTotal = 4.60m;
                    var expectedDiscountedTotal = 3.45m;
                    var expectedLineCount = 1;

                    // Add 4 milk
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);

                    var model = (controller.Index(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(model.ProductLineItems.Count == expectedLineCount);
                    Assert.True(model.Total == expectedOriginalTotal); // Basket total before discount

                    var updatedViewModel = (controller.UpdateTotal(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(updatedViewModel.Total == expectedDiscountedTotal); // Basket Total after update
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        [Fact]
        public void Option4_TestDiscount_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);
                // Add products and discounts to Test DB
                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    var repo = new SupermarketRepository(context);
                    var controller = new BasketController(repo);
                    var expectedOriginalTotal = 11.80m;
                    var expectedDiscountedTotal = 9.00m;
                    var expectedLineCount = 3;

                    // Add 2 butter, 1 bread and 8 milk
                    controller.AddToBasket(1);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(2);
                    controller.AddToBasket(3);
                    controller.AddToBasket(3);

                    var model = (controller.Index(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(model.ProductLineItems.Count == expectedLineCount);
                    Assert.True(model.Total == expectedOriginalTotal); // Basket total before discount

                    var updatedViewModel = (controller.UpdateTotal(_basketId) as ViewResult).Model as BasketViewModel;
                    Assert.True(updatedViewModel.Total == expectedDiscountedTotal); // Basket Total after update
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
