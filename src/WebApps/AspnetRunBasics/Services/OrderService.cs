using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspWebApp.Extensions;
using AspWebApp.Models;

namespace AspWebApp.Services
{
	public class OrderService : IOrderService
	{
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
		{
            _client = client;
		}

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/Order/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}

