using System.Threading;

namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository repo , IDistributedCache cache) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string UserName, CancellationToken token = default)
        {
            await repo.DeleteBasket(UserName, token);
            await cache.RemoveAsync(UserName, token);
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken token = default)
        {
            var cachedBasket = await cache.GetStringAsync(UserName, token);
            if (!string.IsNullOrEmpty(cachedBasket))
                return  JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

            var basket = await repo.GetBasket(UserName, token);
            await cache.SetStringAsync(UserName, JsonSerializer.Serialize(basket), token);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            await repo.StoreBasket(basket, cancellationToken);

            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

            return basket;
        }
    }
}
