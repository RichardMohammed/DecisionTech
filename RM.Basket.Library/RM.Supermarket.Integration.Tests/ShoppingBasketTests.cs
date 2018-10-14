using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RM.Basket.Library;
using RM.Supermarket.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace RM.Supermarket.Integration.Tests
{
    // TEST SAVING TO AN ACTUAL REPO
    // Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
    // Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
    // Given the basket has 4 milk when I total the basket then the total should be £3.45
    // Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00

    //https://www.aspnetmonsters.com/2016/11/2016-11-27-integration-testing-with-entity-framework-core-and-sql-server/

    public class ShoppingBasketTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ShoppingBasket _basket;
        private readonly Product _bread;
        private readonly Product _milk;
        private readonly Product _butter;
        private readonly SupermarketRepository _repo;
        public ShoppingBasketTests(ITestOutputHelper output)
        {
            //_output = output;
            //// Get a live test database and basket
            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DiscountSupermarket;Trusted_Connection=True;MultipleActiveResultSets=true")
            // .Options;
            //var dbContext = new AppDbContext(options);



            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database=DiscountSupermarket{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
                    .UseInternalServiceProvider(serviceProvider);

            var dbContext = new AppDbContext(builder.Options);
            dbContext.Database.Migrate();




            //_repo = new SupermarketRepository(dbContext);
            //_basket = ShoppingBasket.GetBasket(2);

            //_bread = _repo.GetProductById(1);
            //_milk = _repo.GetProductById(2);
            //_butter = _repo.GetProductById(3);

        }
        [Fact]
        public void NoDscountsApplicable()
        {
            Assert.True(1 == 1);
          //  _output.WriteLine(_butter.Id.ToString());
        }
    }
}
