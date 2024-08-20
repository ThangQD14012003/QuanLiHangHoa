using ApiQuanlikho.Models;
using ApiQuanlikho.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuanlikho.Controllers
{
    [Route("api/[controller]")]

    [Authorize]
    [ApiController]
    
    public class MyCustomerController : ControllerBase
    {
        private readonly ICustomerRepository _Icus;

        public MyCustomerController(ICustomerRepository customerRepository)
        {
            _Icus = customerRepository;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _Icus.GetAllCustomerAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Cus = await _Icus.GetCustomerByIdAsync(id);
            return Cus == null ? NotFound() : Ok(Cus);
        }
        [HttpPost]

        public async Task<IActionResult> AddCus(CustomerModel c)
        {
            try
            {
                //    var newCus = await _Icus.AddCustomerAsync(c);
                //    var Cus = await _Icus.GetCustomerByIdAsync(newCus.id);
                //    thằng này lúc đầu làm thế này là sai vì _Icus.AddCustomerAsync(c) k có giá trị trả về
                var newCus = await _Icus.AddCustomerAsync(c);
                var Cus = await _Icus.GetCustomerByIdAsync(newCus); 
                //return Ok(Cus);
                return Cus == null?NotFound():Ok(Cus);   
            }
            catch
            {
                return BadRequest();
            }
            //public async Task<IActionResult> Add(OrderModel model)
            //{
            //    try
            //    {
            //        var newOr = await _IOr.AddOrderAsync(model);
            //        var order = await _IOr.GetOrderByIdAsync(newOr);
            //        return order == null ? NotFound() : Ok(order);
            //    }
            //    catch
            //    {
            //        return BadRequest();
            //    }
            //}
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCus(CustomerModel Model, int id)
        {
            if (id != Model.Id)
            {
                return NotFound();
            }
            await _Icus.UpdateCustomerAsync(Model, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        // bị lỗi ban đầu để [HttpDelete] nên phần fe k nhận được
        public async Task<IActionResult> DeleteCus(int id)
        {
            await _Icus.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
