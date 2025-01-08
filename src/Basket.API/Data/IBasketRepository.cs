namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string UserName, CancellationToken token = default);
        Task<ShoppingCart> StoreBasket(ShoppingCart basket , CancellationToken token = default);
        Task<bool> DeleteBasket(string UserName, CancellationToken token = default);

    }
}
