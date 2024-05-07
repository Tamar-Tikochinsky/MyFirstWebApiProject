using entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderItemServices : IOrderItemServices
    {
        IOrderItemRepoditory _OrderItemRepository;
        public OrderItemServices(IOrderItemRepoditory orderItemRepository)
        {
            _OrderItemRepository = orderItemRepository;
        }
        public async Task<OrderItem> addOrderItem(OrderItem orderItem)
        {
            return await _OrderItemRepository.addOrderItem(orderItem);
        }

        public async Task<OrderItem> getOrderItemById(int id)
        {
            return await _OrderItemRepository.getOrderItemById(id);
        }

        public async Task<IEnumerable<OrderItem>> getOrderItems()
        {
            return await _OrderItemRepository.getOrderItems();
        }
    }
}
