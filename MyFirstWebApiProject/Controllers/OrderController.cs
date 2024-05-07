using AutoMapper;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Repository;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices _OrderServices;
        IMapper mapper;
        public OrderController(IOrderServices orderServices, IMapper _mapper)
        {
            _OrderServices = orderServices;
            mapper = _mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            IEnumerable<Order> orders = await _OrderServices.getOrders();
            IEnumerable<OrdersDTO> ordersDTOs = mapper.Map<IEnumerable<Order>, IEnumerable<OrdersDTO>>(orders);
            return Ok(ordersDTOs);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrdersDTO> getOrderById(int id)
        {
            Order order = await _OrderServices.getOrderById(id);
            OrdersDTO orderDTO = mapper.Map<Order,OrdersDTO>(order);
            return orderDTO;
        }


        // POST api/<OrderController>
        [HttpPost]
        public async Task<OrdersDTO> Post([FromBody] OrderPostDTO order)
        {
            //ICollection<OrderItem> orderItemDTO = mapper.Map<ICollection<OrderItemProdIdDTO>, ICollection<OrderItem>>(order.OrderItems);
            Order orderToAdd = mapper.Map<OrderPostDTO, Order>(order);
            Order theAddOrder = await _OrderServices.addOrder(orderToAdd);
            OrdersDTO newAddOrder = mapper.Map<Order, OrdersDTO>(theAddOrder);
            return newAddOrder;
        }

  
    }
}
