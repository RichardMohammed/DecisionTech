﻿using Microsoft.EntityFrameworkCore;
using RM.Basket.Library;

namespace RM.Supermarket.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLineItem> BasketLineItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}
