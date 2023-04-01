using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
	public class OrderService : IOrderService
	{
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
		{
            _client = client;
		}

        public Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

