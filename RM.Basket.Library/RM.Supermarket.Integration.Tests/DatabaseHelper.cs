using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RM.Basket.Library;
using RM.Supermarket.Models;

namespace RM.Supermarket.Integration.Tests
{
    public class DatabaseHelper
    {
        static Product _bread;
        static Product _milk;
        static Product _butter;
        static Discount _fiftyOff;
        static Discount _1free;

        static DatabaseHelper()
        {
            _fiftyOff = new Discount {Id = 1, DiscountAmount = 50m, TargetProductId = 1 };
            _1free = new Discount {Id = 2, DiscountAmount = 100m, TargetProductId = 2 };
            _bread = new Product { Id = 1, Name = "Bread", Price = 1.00m, ImageThumbnailUrl = "/images/breadThumb.jpg" };
            _milk = new Product { Id = 2, Name = "Milk", Price = 1.15m, Discount = _1free, ImageThumbnailUrl = "/images/milkThumb.jpg" };
            _butter = new Product { Id = 3, Name = "Butter", Price = 0.80m, Discount = _fiftyOff, ImageThumbnailUrl = "/images/butterThumb.jpg" };
        }

        public static DbContextOptions<AppDbContext> GetContextOptions(SqliteConnection connection)
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite(connection)
                    .Options;
        }

        public static void SetupProducts(SqliteConnection connection)
        {
            var options = DatabaseHelper.GetContextOptions(connection);
            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            using (var context = new AppDbContext(options))
            {
                context.Discounts.Add(_fiftyOff);
                context.Discounts.Add(_1free);
                context.Products.Add(_bread);
                context.Products.Add(_milk);
                context.Products.Add(_butter);

                context.SaveChanges();
            }
        }

    }
}
