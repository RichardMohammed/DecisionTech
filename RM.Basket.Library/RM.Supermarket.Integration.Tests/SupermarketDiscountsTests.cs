using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RM.Supermarket.Models;
using RM.Basket.Library;

namespace RM.Supermarket.Integration.Tests
{

//• Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
//• Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
//• Given the basket has 4 milk when I total the basket then the total should be £3.45
//• Given the basket

    public class SupermarketDiscountsTests
    {
        SqliteConnection _connection;
        Product _bread;
        Product _milk;
        Product _butter;
        Discount _fiftyOff;
        Discount _1free;
        public SupermarketDiscountsTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");

            _fiftyOff = new  Discount { DiscountAmount = 50m, TargetProductId = 1 };
            _1free = new Discount { DiscountAmount = 100m, TargetProductId = 2 };
            _bread = new Product { Id = 1, Name = "Bread", Price = 1.00m, ImageThumbnailUrl = "/images/breadThumb.jpg" };
            _milk = new Product { Id = 2, Name = "Milk", Price = 1.15m, ImageThumbnailUrl = "/images/milkThumb.jpg"};
            _butter = new Product { Id = 3, Name = "Butter", Price = 0.80m, ImageThumbnailUrl = "/images/butterThumb.jpg" };
        }

        [Fact]
        public void AddData_ToDatabase_Success()
        {
            try
            {
                _connection.Open();
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite(_connection)
                    .Options;

                // Create the schema in the database
                using (var context = new AppDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new AppDbContext(options))
                {
                    context.Discounts.Add(_fiftyOff);
                    context.Discounts.Add(_1free);
                    context.Products.Add(_bread);
                    context.Products.Add(_milk);
                    context.Products.Add(_butter);

                    context.SaveChanges();
                }

                using (var context = new AppDbContext(options))
                {
                    Assert.Equal(3, context.Products.Count());
                }

            }
            finally
            {
                _connection.Close();
            }
        }
    }
}