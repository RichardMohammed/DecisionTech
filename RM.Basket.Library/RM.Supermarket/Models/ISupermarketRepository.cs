using RM.Basket.Library;
using System.Collections.Generic;

namespace RM.Supermarket.Models
{
    public interface ISupermarketRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        IEnumerable<IProductLineItem> GetAllLineItemsByBasketId(int basketId);
        void SaveBasketLineItem(int basketId, IProductLineItem lineItem);
        void DeleteLineItem(int basketLineId);
        int GetBasketItemsCount(int basketId);
    }
}
