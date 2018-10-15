using Xunit;
using Microsoft.Data.Sqlite;
using RM.Supermarket.Models;
using RM.Supermarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using RM.Supermarket.ViewModels;

namespace RM.Supermarket.Integration.Tests
{
    public class HomeControllerTests
    {
        SqliteConnection _connection;

        public HomeControllerTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
        }

        [Fact]
        public void HomeController_ProductsView_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);

                using (var context = new AppDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Add products to Test DB
                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    var repo = new SupermarketRepository(context);
                    var controller = new HomeController(repo);
                    var result = controller.Index() as ViewResult;

                    Assert.NotNull(result);
                    HomeViewModel model = result.Model as HomeViewModel;
                    Assert.True(model.BasketId == 1);
                    Assert.True(model.Products.Count == 3);
                }
            }
            finally
            {
                _connection.Close();
            }

        }
    }
}
