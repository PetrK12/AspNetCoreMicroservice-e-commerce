using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspWebApp.Models;

namespace AspWebApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}

