using entities.Models;

namespace Services
{
    public interface IOrderItemServices
    {
        Task<OrderItem> addOrderItem(OrderItem orderItem);
        Task<IEnumerable<OrderItem>> getOrderItems();
        Task<OrderItem> getOrderItemById(int id);
    }
}