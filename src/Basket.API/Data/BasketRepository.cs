namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string UserName, CancellationToken token = default)
        {
            session.Delete<ShoppingCart>(UserName);
            await session.SaveChangesAsync(token);
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken token = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(UserName, token);
            return basket is null ? throw new BasketNotFoundException(UserName) : basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken token = default)
        {
            session.Store(basket);
            await session.SaveChangesAsync(token);
            return basket;
        }
    }
}
