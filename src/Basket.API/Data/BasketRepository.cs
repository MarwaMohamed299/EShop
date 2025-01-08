
namespace Basket.API.Data
{
    public class BasketRepository : IBasketRepository
    {
        public Task<bool> DeleteBasket(string UserName, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetBasket(string UserName, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
