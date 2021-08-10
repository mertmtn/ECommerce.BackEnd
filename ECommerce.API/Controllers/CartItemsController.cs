using ECommerce.Business.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private ICartItemService _cartItemService;
        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost("AddToCart")]
        public IActionResult Add(CartItem cartItem)
        {
            var result = _cartItemService.Add(cartItem);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpDelete("RemoveFromCart")]
        public IActionResult Delete(CartItem cartItem)
        {
            var result = _cartItemService.Delete(cartItem);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
