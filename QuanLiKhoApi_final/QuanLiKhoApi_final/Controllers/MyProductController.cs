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


    public class MyProductController : ControllerBase
    {
        private readonly IProductRepository _IPro;

        public MyProductController(IProductRepository productRepository)
        {
            _IPro = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _IPro.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Pro = await _IPro.GetById(id);
            return Ok(Pro);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                await _IPro.DeleteById(id);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update( ProductModel model, int id)
        // public async Task<IActionResult> Update([FromForm] ProductModel model, int id): lúc đầu để như này không ra, rồi ngày 30/6 sửa lại lại ra 
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _IPro.Update(model, id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductModel model)
        {
            try
            {
                var newPro = await _IPro.Add(model);
                var Pro = await _IPro.GetById(newPro);
                return Pro == null ? NotFound() : Ok(Pro);
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
