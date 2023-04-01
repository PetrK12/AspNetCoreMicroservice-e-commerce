using System;
using System.Net.Http;
using System.Threading.Tasks;
using AspWebApp.Models;

namespace AspWebApp.Services
{
	public class BasketService : IBasketService
	{
        private readonly HttpClient _client;

		public BasketService(HttpClient client)
		{
            _client = client;
		}

        public Task CheckoutBasket(BasketCheckoutModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> UpdateBasket(BasketModel model)
        {
            throw new NotImplementedException();
        }
    }
}

