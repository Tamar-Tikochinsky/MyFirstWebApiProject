using AutoMapper;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemServices _OrderItemServices;
        IMapper mapper;
        public OrderItemController(IOrderItemServices orderItemServices, IMapper _mapper)
        {
            _OrderItemServices = orderItemServices;
            mapper= _mapper;
        }
        // GET: api/<OrderItemController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> Get()
        {
            IEnumerable<OrderItem> orderItems = await _OrderItemServices.getOrderItems();
            IEnumerable<OrderItemDTO> orderItemDTOs = mapper.Map<IEnumerable<OrderItem>,IEnumerable<OrderItemDTO>>(orderItems); 
            return Ok(orderItemDTOs);

        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public async Task<OrderItemDTO> getOrderItemById(int id)
        {
            OrderItem orderItem = await _OrderItemServices.getOrderItemById(id);
            OrderItemDTO orderItemDTO = mapper.Map<OrderItem,OrderItemDTO>(orderItem);
            return orderItemDTO;
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<OrderItemDTO> Post([FromBody] OrderItemPostDTO orderItemToAdd)
        {
            OrderItem orderItem = mapper.Map<OrderItemPostDTO, OrderItem>(orderItemToAdd);
            OrderItem theAddOrderItem = await _OrderItemServices.addOrderItem(orderItem);
            OrderItemDTO orderItemDTO = mapper.Map<OrderItem,OrderItemDTO>(theAddOrderItem);
            return orderItemDTO;
        }
    }
}
