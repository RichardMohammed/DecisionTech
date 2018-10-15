using Xunit;
using Microsoft.Data.Sqlite;
using System.Linq;
using RM.Supermarket.Models;
using RM.Basket.Library;
using RM.Supermarket.Controllers;
using Microsoft.AspNetCore.Mvc;
using RM.Supermarket.ViewModels;

namespace RM.Supermarket.Integration.Tests
{
    public class SupermarketDiscountsTests
    {
        SqliteConnection _connection;
        public SupermarketDiscountsTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
        }

        [Fact]
        public void AddData_ToDatabase_Success()
        {
            try
            {
                _connection.Open();
                var options = DatabaseHelper.GetContextOptions(_connection);
                // Create the schema in the database
                using (var context = new AppDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                DatabaseHelper.SetupProducts(_connection);

                using (var context = new AppDbContext(options))
                {
                    Assert.Equal(3, context.Products.Count());
                    Assert.Equal(2, context.Discounts.Count());
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}