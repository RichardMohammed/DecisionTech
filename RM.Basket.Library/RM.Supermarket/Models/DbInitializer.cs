using RM.Basket.Library;
using System.Linq;

namespace RM.Supermarket.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            var discount = new Discount {DiscountAmount = 50m, TargetProductId = 1 };
            var discount2 = new Discount {DiscountAmount = 100m, TargetProductId = 2 };

            if (!context.Discounts.Any())
            {
                context.AddRange(discount, discount2);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {

                context.AddRange(
                    new Product {Name = "Bread", Price = 1.00m, ImageThumbnailUrl = "/images/breadThumb.jpg", Description = "Hot bread" },
                    new Product {Discount = discount2, Name = "Milk", Price = 1.15m, ImageThumbnailUrl = "/images/milkThumb.png", Description = "Fresh milk" },
                    new Product {Discount = discount, Name = "Butter", Price = 0.80m, ImageThumbnailUrl = "/images/butterThumb.jpg", Description = "Rich butter" }
                    );
                context.SaveChanges();
            }

            if (context.Discounts.Any())
            {
                var bread = context.Products.FirstOrDefault(p => p.Name == "Bread");
                var milk = context.Products.FirstOrDefault(p => p.Name == "Milk");
                var discount50 = context.Discounts.FirstOrDefault(d => d.DiscountAmount == 50m);
                discount50.TargetProductId = bread.Id;
                var discount100 = context.Discounts.FirstOrDefault(d => d.DiscountAmount == 100m);
                discount100.TargetProductId = milk.Id;
                context.SaveChanges();
            }
        }
    }
}
