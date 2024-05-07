using entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CookwareShopContext _CookwareShopContext;
        public OrderRepository(CookwareShopContext cookwareShopContext)
        {
            _CookwareShopContext = cookwareShopContext;
        }
        public async Task<Order> addOrder(Order order)
        {
            await _CookwareShopContext.Orders.AddAsync(order);
            await _CookwareShopContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> getOrderById(int id)
        {
            return await _CookwareShopContext.Orders.Include(order => order.OrderItems).FirstOrDefaultAsync(o => o.OrderId == id);

        }

        public async Task<IEnumerable<Order>> getOrders()
        {
            return await _CookwareShopContext.Orders.Include(order => order.OrderItems).ToListAsync();

        }
    }
}
