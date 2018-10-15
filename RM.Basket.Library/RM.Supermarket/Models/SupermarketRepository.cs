using System.Collections.Generic;
using System.Linq;
using RM.Basket.Library;

namespace RM.Supermarket.Models
{
    public class SupermarketRepository : ISupermarketRepository
    {
        private readonly AppDbContext _appDbContext;

        public SupermarketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<IProductLineItem> GetAllLineItemsByBasketId(int basketId)
        {
            return _appDbContext.BasketLineItems.Where(b => b.BasketId == basketId)
                .Join(_appDbContext.Products, li => li.Product.Id, p => p.Id, (lineitem,product) => new{ a=lineitem, b= product })
                .GroupJoin(_appDbContext.Discounts, pd => pd.b.Discount.Id, d => d.Id, (pd, d) => new {pd, d })
                .SelectMany(discounts => discounts.d.DefaultIfEmpty(),
                (lt, discounts) => new ProductLineItem() {
                    BasketId = lt.pd.a.BasketId, Id = lt.pd.a.Id,
                    DiscountedLineCost = lt.pd.a.DiscountedLineCost, Quantity = lt.pd.a.Quantity,
                    Product = new Product { Id = lt.pd.b.Id, Description = lt.pd.b.Description, ImageThumbnailUrl = lt.pd.b.ImageThumbnailUrl,
                                            ImageUrl = lt.pd.b.ImageUrl, Name = lt.pd.b.Name, Price = lt.pd.b.Price, Discount = discounts },
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _appDbContext.Products;
        }

        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void SaveBasketLineItem(int basketId, IProductLineItem lineItem)
        {
            var basketItem = _appDbContext.BasketLineItems.FirstOrDefault(l => l.BasketId == basketId && l.Product.Id == lineItem.Product.Id);
            if(basketItem != null)
            {
                basketItem.Quantity = lineItem.Quantity;
            }
            else
            {
                basketItem = new ProductLineItem { BasketId = basketId, Quantity = lineItem.Quantity, DiscountedLineCost = lineItem.DiscountedLineCost, Product = lineItem.Product };
                _appDbContext.BasketLineItems.Add(basketItem);
            }

            _appDbContext.SaveChanges();

        }

        public void DeleteLineItem(int basketLineItemId)
        {
            _appDbContext.BasketLineItems.Remove(_appDbContext.BasketLineItems.Find(basketLineItemId));
            _appDbContext.SaveChanges();
        }

        public int GetBasketItemsCount(int basketId)
        {
            return _appDbContext.BasketLineItems.Where(li => li.BasketId == basketId)
                .Sum(i => i.Quantity);
        }
    }
}
