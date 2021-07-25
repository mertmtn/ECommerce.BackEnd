using ECommerce.Business.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
 
namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetByProductId")]
        public IActionResult GetByProductId(string productId)
        {
            var result = _productService.GetById(productId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
