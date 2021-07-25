using ECommerce.Business.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc; 

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
