using Basket.API.Models;

namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        public Task<ShoppingCart> GetBasket(string userName);

        public Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

        public Task DeleteBasket(string userName);
    }
}

