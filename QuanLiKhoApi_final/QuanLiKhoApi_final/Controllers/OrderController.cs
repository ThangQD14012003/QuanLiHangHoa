using ApiQuanlikho.Models;
using ApiQuanlikho.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuanlikho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _IOr;

        public OrderController(IOrderRepository orderRepository)
        {
            _IOr = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _IOr.GetAllOrderAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _IOr.GetOrderByIdAsync(id);   
            return order == null ? NotFound() : Ok(order);  
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderModel model)
        {
            try
            {
                var newOr = await _IOr.AddOrderAsync(model);
                var order = await _IOr.GetOrderByIdAsync(newOr);
                return order == null ? NotFound() : Ok(order);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOr(OrderModel Order, int id)
        {
            if (id != Order.Id)
            {
                return NotFound();
            }
            await _IOr.UpdateOrderAsync(Order, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _IOr.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
