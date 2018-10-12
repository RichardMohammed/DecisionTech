namespace RM.Basket.Library
{
    public interface IProductLineItem
    {
        int Id { get; set; }
        int BasketId { get; set; }
        Product Product { get; set; }
        int Quantity { get; set; }
        decimal DiscountedLineCost { get; set; }
        bool DiscountApplied { get; set; }
    }
}