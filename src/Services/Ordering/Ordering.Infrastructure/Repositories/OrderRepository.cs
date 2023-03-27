using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistance;

namespace Ordering.Infrastructure.Repositories
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
        public OrderRepository(OrderContext context) :base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _context.Orders
                                     .Where(o => o.UserName == userName)
                                     .ToListAsync();
            return orderList;
        }
    }
}

