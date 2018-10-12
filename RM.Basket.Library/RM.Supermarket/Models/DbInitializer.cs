using Microsoft.EntityFrameworkCore;
using RM.Basket.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RM.Supermarket.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                context.AddRange(
                    new Product {DiscountCode = 0, Name = "Bread", Price = 1.00m, ImageThumbnailUrl = "/images/breadThumb.jpg", Description = "Hot bread" },
                new Product {DiscountCode = 2, Name = "Milk", Price = 1.15m, ImageThumbnailUrl = "/images/milkThumb.png", Description = "Fresh milk" },
                new Product {DiscountCode = 3, Name = "Butter", Price = 0.80m, ImageThumbnailUrl = "/images/butterThumb.jpg", Description = "Rich butter" }
                    );
                context.SaveChanges();
            }
        }
    }
}
