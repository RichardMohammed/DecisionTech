using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RM.Basket.Library;

namespace RM.Supermarket.Models
{
    public class MockSupermarketRepository : ISupermarketRepository
    {
        private List<Product> _products;
        private List<ProductLineItem> _productLineItems;
        public MockSupermarketRepository()
        {
            if (_products == null)
            {
                InitiliseProducts();
            }

            if (_productLineItems == null)
            {
                InitiliseProductLineItems();
            }

        }
        public IEnumerable<IProductLineItem> GetAllLineItemsByBasketId(int basketId)
        {
            return _productLineItems.Where(p => p.BasketId == basketId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        private void InitiliseProducts()
        {
            var discount = new Discount { Id = 3, DiscountAmount = 50m, TargetProductId = 1 };
            var discount2 = new Discount { Id = 2, DiscountAmount = 100m, TargetProductId = 2 };
            _products = new List<Product>
            {
                new Product {Name = "Bread", Price = 1.00m, ImageThumbnailUrl = "/images/breadThumb.jpg", Description = "Hot bread" },
                new Product {Discount = discount2, Name = "Milk", Price = 1.15m, ImageThumbnailUrl = "/images/milkThumb.png", Description = "Fresh milk" },
                new Product {Discount = discount, Name = "Butter", Price = 0.80m, ImageThumbnailUrl = "/images/butterThumb.jpg", Description = "Rich butter" }
            };
        }

        private void InitiliseProductLineItems()
        {
            _productLineItems = new List<ProductLineItem>
            {
                new ProductLineItem
                {
                    BasketId = 1,
                    Product = new Product { Id = 1, Name = "Bread", Price = 1.00m, ImageThumbnailUrl="/images/breadThumb.jpg", Description="Hot bread" },
                    Quantity = 1
                },
                new ProductLineItem
                {
                    BasketId = 1,
                    Product = new Product { Id = 2, Name = "Milk", Price = 1.15m, ImageThumbnailUrl="/images/milkThumb.png", Description="Fresh milk"},
                    Quantity = 1
                },
                new ProductLineItem
                {
                    BasketId = 1,
                    Product = new Product { Id = 3, Name = "Butter", Price = 0.80m, ImageThumbnailUrl="/images/butterThumb.jpg", Description="Rich butter" },
                    Quantity = 1
                }
            };
        }

        public void SaveBasketLineItem(int basketId, IProductLineItem lineItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineItem(int basketLineId)
        {
            throw new NotImplementedException();
        }
    }
}
