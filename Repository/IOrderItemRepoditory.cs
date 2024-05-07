using entities.Models;

namespace Repository
{
    public interface IOrderItemRepoditory
    {
        Task<OrderItem> addOrderItem(OrderItem orderItem);
        Task<OrderItem> getOrderItemById(int id);
        Task<IEnumerable<OrderItem>> getOrderItems();
    }
}