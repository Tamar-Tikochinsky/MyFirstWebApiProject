using entities.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        IProductsRepository _productsRepository;

        IOrderRepository _OrderRepository;
        public OrderServices(IOrderRepository orderRepository, IProductsRepository productsRepository)
        {
            _OrderRepository = orderRepository;
            _productsRepository = productsRepository;
        }
        public async Task<Order> addOrder(Order order)
        {
            List<int> lst = new List<int>();
            foreach (var orderItem in order.OrderItems)
            {
                lst.Add((int)orderItem.ProductId);
            }
            decimal sum = await _productsRepository.checkSumOrder(lst);
           
            if (sum != order.OrderSum) { 
              order.OrderSum = sum;
            }
            return await _OrderRepository.addOrder(order);
        }

        public async Task<Order> getOrderById(int id)
        {
            return await _OrderRepository.getOrderById(id);
        }

        public async Task<IEnumerable<Order>> getOrders()
        {
            return await _OrderRepository.getOrders();
        }
    }
}
