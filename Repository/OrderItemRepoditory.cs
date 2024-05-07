using entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderItemRepoditory : IOrderItemRepoditory
    {
        private readonly CookwareShopContext _CookwareShopContext;
        public OrderItemRepoditory(CookwareShopContext cookwareShopContext)
        {
            _CookwareShopContext = cookwareShopContext;
        }
        public async Task<OrderItem> addOrderItem(OrderItem orderItem)
        {
            await _CookwareShopContext.OrderItems.AddAsync(orderItem);
            await _CookwareShopContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> getOrderItemById(int id)
        {
            return await _CookwareShopContext.OrderItems.FindAsync(id);

        }

        public async Task<IEnumerable<OrderItem>> getOrderItems()
        {
            return await _CookwareShopContext.OrderItems.ToListAsync();
        }
    }
}
