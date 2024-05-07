using entities.Models;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        Task<Order> getOrderById(int id);
        Task<IEnumerable<Order>> getOrders();
    }
}