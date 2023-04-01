using System;
using AspWebApp.Models;
using System.Threading.Tasks;

namespace AspWebApp.Services
{
	public interface IBasketService
	{
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel model);
        Task CheckoutBasket(BasketCheckoutModel model);
    }
}

