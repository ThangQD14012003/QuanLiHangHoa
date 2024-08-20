using ApiQuanlikho.Models;
using ApiQuanlikho.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuanlikho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountRepository _accoutRepository;

        public AcountController(IAcountRepository accoutRepository)
        {
            _accoutRepository = accoutRepository;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await _accoutRepository.SigUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SigIn(SignInModel model)
        {
            var result = await _accoutRepository.SigInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
