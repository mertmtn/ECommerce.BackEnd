using ECommerce.Business.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;  

 
namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Cart cart)
        {
            var result = _cartService.Add(cart);
            return StatusCode(result.Success ? 200 : 400, result);
        }

 
    }
}
